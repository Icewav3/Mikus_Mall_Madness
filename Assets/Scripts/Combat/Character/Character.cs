using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Character : MonoBehaviour
{
	public event Action<Character> OnDeath;
	public event Action<Character, DamageEvent> OnDamage;
	public event Action<Character, int> OnHeal;
	public event Action<Character, int> OnStaminaDeplete;
	public event Action<Character, int> OnStaminaGain;

	[SerializeField]
	private CharacterBase _characterBase;
	public CharacterBase CharacterBase => _characterBase;

	[SerializeField]
	private bool _isEnemy;
	public bool IsEnemy => _isEnemy;

	public bool IsDead { get; private set; }

	#region Stats
	private List<StatBoost> _activeStatBoosts = new List<StatBoost>();
	public List<StatBoost> ActiveStatBoosts => _activeStatBoosts;

	private int _currentHealth;
	public int CurrentHealth => _currentHealth;

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

	private float _attack = 1;
	public float Attack
	{
		get { return ApplyStatBoosts(_attack, StatTypes.Attack); }
	}

	public float ApplyStatBoosts(float baseValue, StatTypes statType)
	{
		float modifiedStat = baseValue;

		List<StatBoost> applicableBoosts = ActiveStatBoosts.Where(sb => sb.StatIncrease == statType).ToList();
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

		float defenseMultiplier = 1 - Defense / (100 + Mathf.Abs(Defense));
		int appliedDamage = Mathf.FloorToInt(damage * defenseMultiplier);

		_currentHealth -= appliedDamage;

		OnDamage?.Invoke(this, new DamageEvent(appliedDamage, damage));

		if(_currentHealth <= 0)
		{
			IsDead = true;
			OnDeath?.Invoke(this);
		}
	}

	public void Heal(int heal)
	{
		if (heal <= 0) return;

		_currentHealth += heal;

		OnHeal?.Invoke(this, heal);
	}

	public void DepleteStamina(int stamina)
	{
		if (stamina <= 0) return;

		OnStaminaDeplete?.Invoke(this, stamina);
	}

	public void GainStamina(int stamina)
	{
		if (stamina <= 0) return;

		OnStaminaGain?.Invoke(this, stamina);
	}
	#endregion
}

public class DamageEvent
{
	public DamageEvent(int appliedDamage, int damage)
	{
		AppliedDamage = appliedDamage;
		Damage = damage;
	}

	public int AppliedDamage { get; private set; }
	public int Damage { get; private set;}
}