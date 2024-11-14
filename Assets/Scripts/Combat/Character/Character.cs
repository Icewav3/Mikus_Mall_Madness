using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Linq;

public class Character : MonoBehaviour
{
	public event Action<Character> OnDeath;

	[SerializeField]
	private CharacterBase _characterBase;
	public CharacterBase CharacterBase => _characterBase;

	[SerializeField]
	private bool _isEnemy;
	public bool IsEnemy => _isEnemy;

	#region Stats
	private List<StatBoost> _activeStatBoosts = new List<StatBoost>();
	public List<StatBoost> ActiveStatBoosts => _activeStatBoosts;

	private int _currentHealth;
	public int CurrentHealth => _currentHealth;

	public int MaxHealth
	{
		get { return ApplyStatBoosts(CharacterBase.BaseHealth, StatTypes.MaxHealth); }
	}

	public int MaxStamina
	{
		get { return ApplyStatBoosts(CharacterBase.BaseStamina, StatTypes.MaxStamina); }
	}

	public int Speed
	{
		get { return ApplyStatBoosts(CharacterBase.BaseSpeed, StatTypes.Speed); }
	}

	public int Defense
	{
		get { return ApplyStatBoosts(CharacterBase.BaseDefense, StatTypes.Defense); }
	}

	public int Attack
	{
		get { return ApplyStatBoosts(CharacterBase.BaseAttack, StatTypes.Attack); }
	}

	public int ApplyStatBoosts(int baseValue, StatTypes statType)
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

		return Mathf.FloorToInt(modifiedStat);
	}
	#endregion Stats
}
