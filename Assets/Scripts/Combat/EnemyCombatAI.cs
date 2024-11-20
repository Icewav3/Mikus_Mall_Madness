using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class EnemyCombatAI : MonoBehaviour
{
	// Handle Enemy combat turn

	// TO DO: pick an action at random

	// add priority to certain actions
	// depending on the enemy's action selection

	private List<Character> _allies;
	private List<Character> _opponents;
	private List<CombatAction> _combatActions;
	private List<ActionBehaviourType> _behaviourTypes;
	private Character _character;

	private int _action;
	private int _target;

	public void HandleEnemyAction(Character character, List<Character> allies, List<Character> opponents)
	{
		_allies = allies;
		_opponents = opponents;
		_character = character;

		// Get list of available actions
		_combatActions = _character.CombatActions.ToList();
		// Get list of action types
		List<ActionBehaviourType> BehaviourTypes = _behaviourTypes.ToList();

		_action = Random.Range(0, _combatActions.Count);

		HandleEnemyTarget();
	}

	private void HandleEnemyTarget()
	{
		// 1. check actions
		// 2. target alley or opponent based on action type

		if (_combatActions[_action].TargetAllies) { TargetAlly(); }
		else { TargetOpponent(); }
	}

	private void TargetAlly()
	{
		// Heal allies with the lowest health
		// Buff unbuffed allies: prioritize higher attack

		// heal
		/*
		if (_combatActions[_action].BehaviourTypes)
		{

		}
		// buff
		else if ()
		{

		}*/
	}

	private void TargetOpponent()
	{
		// Attack: target alive opponents at random
	}
}