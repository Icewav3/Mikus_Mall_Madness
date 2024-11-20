using System;

using UnityEngine;

///<summary>
///  Class that represents an instance of a boost to a <see cref="Character"/>'s stats.
///</summary>
[Serializable]
public class StatBoost
{
	///<param name="statIncrease">The stat to be modified.</param>
	///<param name="type">The way the stat boost should be applied to the base stat.</param>
	///<param name="amount">The amount the stat should be increased by.</param>
	public StatBoost(StatTypes statIncrease, StatBoostTypes type, float amount)
	{
		_statIncrease = statIncrease;
		_type = type;
		_amount = amount;
	}

	[SerializeField]
	private StatTypes _statIncrease;
	public StatTypes StatIncrease => _statIncrease;

	[SerializeField, Tooltip("How should the boost be applied to the base value?")]
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

///<summary>
///  How a <see cref="StatBoost"/> is applied to the base value.
///  <para>Possible values: <see cref="Additive"/>, <see cref="Multiplicative"/>.</para>
///</summary>
public enum StatBoostTypes
{
	///<summary>BaseValue + boost</summary>
	Additive,
	///<summary>BaseValue * boost</summary>
	Multiplicative
}