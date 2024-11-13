using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatBoost
{
    public StatBoost(StatTypes statIncrease, StatBoostTypes type, float amount)
	{
		_statIncrease = statIncrease;
		_type = type;
		_amount = amount;
	}

	[SerializeField]
	private StatTypes _statIncrease;
	public StatTypes StatIncrease => _statIncrease;

	[SerializeField]
	private StatBoostTypes _type;
	public StatBoostTypes Type => _type;

	[SerializeField]
	private float _amount;
	public float Amount => _amount;
}

public enum StatTypes
{
	MaxHealth,
	MaxStamina,
	Speed,
	Defense,
	Attack
}

public enum StatBoostTypes
{
	Addative,
	Multiplicative
}