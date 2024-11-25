using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

[CreateAssetMenu(fileName = "Combat Action", menuName = "")]
public class CombatAction : ScriptableObject
{
	[SerializeField]
	private string _displayName;
	public string DisplayName => _displayName;
	// whether the action allows you to target allies or not after choosing it
	[SerializeField]
	private bool _targetAllies;
	public bool TargetAllies => _targetAllies;

	[SerializeField]
	private List<ActionEffect> _effects;

	// instructions for animator on which animation to link it to
	[SerializeField]
	private ActionAnimType _animType;
	public ActionAnimType AnimType => _animType;

	// a list of "action categories" for the enemy AI to use when selecting its moves
	[SerializeField]
	private List<ActionBehaviourType> _behaviourTypes;
	public ReadOnlyCollection<ActionBehaviourType> BehaviourTypes => _behaviourTypes.AsReadOnly();

	[SerializeField]
	private int _staminaCost;
	public int StaminaCost => _staminaCost;

	// NOTE: Potentially make override with delay between effects??? might be unneccesary
	public void Perform(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		foreach (ActionEffect effect in _effects)
		{
			effect.Activate(origin, target, enemies, allies);
		}
	}
}

public enum ActionAnimType
{
	Attack1,
	Attack2,
	Status,
	Defend,
	Signature
}

public enum ActionBehaviourType
{
	Attack,
	Buff,
	Debuff,
	Defend,
	Heal
}