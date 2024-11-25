using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using UnityEngine;

///<summary>
///  Class that contains all per instance information related to a character.
///  Base stats are derived from <see cref="CharacterBase"/>.
///</summary>
public class Character
{
	public Character(CharacterBase characterBase)
	{
		_characterBase = characterBase;

		_currentHealth = MaxHealth;
		_currentStamina = MaxStamina;
	}
	public event Action<Character> OnDeath;

	// stat/gain loss events are stored separately for future damage effects systems to use easily
	public event Action<Character, DamageEvent> OnDamage;
	public event Action<Character, int> OnHeal;

	public event Action<Character, int> OnStaminaDeplete;
	public event Action<Character, int> OnStaminaGain;

	public event Action<Character, ActionAnimType> OnAnimationStart;
	public event Action<Character> OnActionPerformed;
	public event Action<Character> OnTurnEnd;

	private CharacterBase _characterBase;
	public CharacterBase Base => _characterBase;

	// shorthand variable to expose the character base's actions
	public ReadOnlyCollection<CombatAction> CombatActions => _characterBase.CombatActions;

	public bool IsEnemy => Base.IsEnemy;

	public string Name => Base.Name;

	// primarily used to ensure multi-targeting attacks don't target dead characters
	///<summary>
	///  Whether the character should be ignored when targeting for an action, or in the turn order.
	///</summary>
	public bool IsDead { get; private set; } = false;

	#region Stats
	private List<StatBoost> _activeStatBoosts = new List<StatBoost>();
	public List<StatBoost> ActiveStatBoosts => _activeStatBoosts;

	private int _currentHealth;
	public int CurrentHealth => _currentHealth;

	private int _currentStamina;
	public int CurrentStamina => _currentStamina;

	public int MaxHealth
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(Base.BaseHealth, StatTypes.MaxHealth)); }
	}

	public int MaxStamina
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(Base.BaseStamina, StatTypes.MaxStamina)); }
	}

	public int Speed
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(Base.BaseSpeed, StatTypes.Speed)); }
	}

	public int Defense
	{
		get { return Mathf.FloorToInt(ApplyStatBoosts(Base.BaseDefense, StatTypes.Defense)); }
	}

	// attack is used as a MULTIPLIER to damage dealt.
	// this is slightly weird with the way stat boosts are handled,
	// as if you wanted to give a 20% attack boost, you'd actually ADD 0.2 to this.
	// sorry!! -cate (we tried to find a way around this but gave up)
	private float _attack = 1;
	///<returns>A multiplier for how much damage should be dealt by the character.</returns>
	public float Attack
	{
		get { return ApplyStatBoosts(_attack, StatTypes.Attack); }
	}

	///<param name="baseValue">The base value the stat to be modified</param>
	///<param name="statType">The type of stat to look for in modifiers.</param>
	///<summary>
	///  Applies all the relevant <see cref="StatBoost"/>s to a given stat.
	///</summary>
	///<returns>
	///  The modified value after all boosts have been applied.
	///  Though most stats are stored as <see cref="int"/>,
	///  we can be more specific by returning <see cref="float"/> in case we need one.
	///</returns>
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
	///<param name="damage">
	///  <para>The amount of damage to deal to the character.</para>
	///  <para>Negative values are ignored.</para>
	///</param>
	///<summary>
	///  <para>
	///    Decreases the character's health.
	///    The amount the health stat is decreased by is not directly solely determined by <paramref name="damage"/>,
	///    but instead uses a formula that takes the character's defense stat into account.
	///  </para>
	///  <para>Also broadcasts and event with the amount of health was gained.</para>
	///</summary>
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
			_currentHealth = 0;
			IsDead = true;
			OnDeath?.Invoke(this);
		}
	}

	///<param name="heal">
	///  <para>The amount of health to add to the character.</para>
	///  <para>Negative values are ignored.</para>
	///</param>
	///<summary>
	///  <para>Increases the character's health stat by <paramref name="heal"/>.
	///  The health stat will not go below 0.</para>
	///  <para>Also broadcasts and event with the amount of health was gained.</para>
	///</summary>
	public void Heal(int heal)
	{
		if (heal <= 0) return;

		int appliedHeal = heal;

		// do not allow overhealing
		if (_currentHealth + heal > MaxHealth)
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

	///<param name="stamina">
	///  <para>The amount of stamina to remove from the character.</para>
	///  <para>Negative values are ignored.</para>
	///</param>
	///<summary>
	///  <para>Decreases the character's stamina stat by <paramref name="stamina"/>.
	///  The stamina stat will not go below 0.</para>
	///  <para>Also broadcasts and event with the amount of stamina was lost.</para>
	///</summary>
	public void DepleteStamina(int stamina)
	{
		// TODO: Add check to prevent stamina from becoming negative
		if (stamina <= 0) return;

		_currentStamina -= stamina;

		OnStaminaDeplete?.Invoke(this, stamina);
	}

	///<param name="stamina">
	///  <para>The amount of stamina to give to the character.</para>
	///  <para>Negative values are ignored.</para>
	///</param>
	///<summary>
	///  <para>Increments the character's stamina stat by <paramref name="stamina"/>.
	///  The stamina stat will not go above <see cref="MaxStamina"/>.</para>
	///  <para>Also broadcasts and event with the amount of stamina was gained.</para>
	///</summary>
	public void GainStamina(int stamina)
	{
		if (stamina <= 0) return;

		int gainedStamina = stamina;

		// do not allow stamina gain past the maximum
		if (_currentStamina + stamina > MaxStamina)
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

	public void StartAnimation(ActionAnimType animType)
	{
		OnAnimationStart?.Invoke(this, animType);
	}
	public void PerformAction()
	{
		OnActionPerformed?.Invoke(this);
	}
	public void EndTurn()
	{
		OnTurnEnd?.Invoke(this);
	}

	public override string ToString()
	{
		return Name;
	}
}

///<summary>
///  Class containing information about an instance of damage.
///</summary>
public class DamageEvent
{
	///<param name="appliedDamage">Damage the target was dealt.</param>
	///<param name="damage">Damage before defense calculations.</param>
	public DamageEvent(int appliedDamage, int damage)
	{
		AppliedDamage = appliedDamage;
		Damage = damage;
	}

	///<returns>The amount of damage actually applied to a target.</returns>
	public int AppliedDamage { get; private set; }
	///<returns>The raw damage number before defense calculations.</returns>
	public int Damage { get; private set; }
}