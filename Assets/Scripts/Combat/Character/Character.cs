using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using UnityEngine;

public class Character : MonoBehaviour
{
	public event Action<Character> OnDeath;

	// stat/gain loss events are stored separately for future damage effects systems to use easily
	public event Action<Character, DamageEvent> OnDamage;
	public event Action<Character, int> OnHeal;

	public event Action<Character, int> OnStaminaDeplete;
	public event Action<Character, int> OnStaminaGain;

	[SerializeField]
	private CharacterBase _characterBase;
	public CharacterBase CharacterBase => _characterBase;

	// shorthand variable to expose the character base's actions
	public ReadOnlyCollection<CombatAction> CombatActions => _characterBase.CombatActions;

	[SerializeField]
	private bool _isEnemy;
	public bool IsEnemy => _isEnemy;

	// primarily used to ensure multi-targeting attacks don't target dead characters
	public bool IsDead { get; private set; }

	#region Stats
	private List<StatBoost> _activeStatBoosts = new List<StatBoost>();
	public List<StatBoost> ActiveStatBoosts => _activeStatBoosts;

	private int _currentHealth;
	public int CurrentHealth => _currentHealth;

	private int _currentStamina;
	public int CurrentStamina => _currentStamina;

	public int MaxHealth
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(CharacterBase.BaseHealth, StatTypes.MaxHealth)); }
	}

	public int MaxStamina
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(CharacterBase.BaseStamina, StatTypes.MaxStamina)); }
	}

	public int Speed
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(CharacterBase.BaseSpeed, StatTypes.Speed)); }
	}

	public int Defense
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(CharacterBase.BaseDefense, StatTypes.Defense)); }
	}

	// attack is used as a MULTIPLIER to damage dealt.
	// this is slightly weird with the way stat boosts are handled,
	// as if you wanted to give a 20% attack boost, you'd actually ADD 0.2 to this.
	// sorry!! -cate (we tried to find a way around this but gave up)
	private float _attack = 1;
	public float Attack
	{
		get { return ApplyStatBoosts(_attack, StatTypes.Attack); }
	}

	// even though most of our stats are stored as ints, we can be more specific by returning a float in case we need one
	public float ApplyStatBoosts(float baseValue, StatTypes statType)
	{
		// store a temporary version of the stat for additive boosts
		float modifiedStat = baseValue;

		// find boosts that match our stat we're trying to increase
		List<StatBoost> applicableBoosts = ActiveStatBoosts.Where(sb => sb.StatIncrease == statType).ToList();

		// used for multiplicative boosts to ensure they are not compounding (10% + 10% = 20% instead of 21%)
		float finalMultiplier = 1;

		foreach (StatBoost boost in applicableBoosts)
		{
			if (boost.Type == StatBoostTypes.Additive)
			{
				modifiedStat += boost.Amount;
			}
			else if (boost.Type == StatBoostTypes.Multiplicative)
			{
				finalMultiplier += boost.Amount;
			}
		}

		modifiedStat *= finalMultiplier;

		return modifiedStat;
	}
	#endregion Stats

	#region Stat Accessors
	public void Damage(int damage)
	{
		if (damage <= 0) return;

		// calculate defense damage reduction (uses a formula that can be found here: https://riskofrain2.fandom.com/wiki/Armor)
		float defenseMultiplier = 1 - Defense / (100 + Mathf.Abs(Defense));
		int appliedDamage = Mathf.FloorToInt(damage * defenseMultiplier);

		_currentHealth -= appliedDamage;

		OnDamage?.Invoke(this, new DamageEvent(appliedDamage, damage));

		if (_currentHealth <= 0)
		{
			IsDead = true;
			OnDeath?.Invoke(this);
		}
	}

	public void Heal(int heal)
	{
		if (heal <= 0) return;

		int appliedHeal = heal;

		// do not allow overhealing
		if(_currentHealth + heal > MaxHealth)
		{
			appliedHeal = MaxHealth - _currentHealth;
			_currentHealth = MaxHealth;
		}
		else
		{
			_currentHealth += heal;
		}

		OnHeal?.Invoke(this, appliedHeal);
	}

	public void DepleteStamina(int stamina)
	{
		if (stamina <= 0) return;

		_currentStamina -= stamina;

		OnStaminaDeplete?.Invoke(this, stamina);
	}

	public void GainStamina(int stamina)
	{
		if (stamina <= 0) return;

		int gainedStamina = stamina;

		// do not allow stamina gain past the maximum
		if(_currentStamina + stamina > MaxStamina)
		{
			gainedStamina = MaxStamina - _currentStamina;
			_currentStamina = MaxStamina;
		}
		else
		{
			_currentStamina += stamina;
		}

		OnStaminaGain?.Invoke(this, gainedStamina);
	}
	#endregion
}

// class to bundle more specific information about an instance of damage
public class DamageEvent
{
	public DamageEvent(int appliedDamage, int damage)
	{
		AppliedDamage = appliedDamage;
		Damage = damage;
	}

	public int AppliedDamage { get; private set; }
	public int Damage { get; private set; }
}