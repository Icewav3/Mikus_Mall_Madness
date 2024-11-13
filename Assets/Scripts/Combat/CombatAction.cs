using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAction : ScriptableObject
{
	[SerializeField]
	private bool _targetAllies;
	public bool TargetAllies => _targetAllies;

	[SerializeField]
	private List<ActionEffect> _effects;
	public List<ActionEffect> Effects => _effects;

	[SerializeField]
	private ActionAnimType _animType;
	public ActionAnimType AnimType => _animType;

	[SerializeField]
	private List<ActionBehaviourType> _behaviourTypes;
	public List<ActionBehaviourType> BehaviourTypes => _behaviourTypes;

	[SerializeField]
	private int _staminaCost;
	public int StaminaCost => _staminaCost;

	public void Perform(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		foreach(ActionEffect effect in _effects)
		{
			effect.Activate(origin, target, enemies, allies);
		}
	}
}

public enum ActionAnimType
{
	Attack,
	Status,
	Defend
}

public enum ActionBehaviourType
{
	Attack,
	Buff,
	Debuff,
	Defend,
	Heal
}