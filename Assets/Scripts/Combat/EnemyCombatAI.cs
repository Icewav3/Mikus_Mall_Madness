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
	private Character _character;

	public CombatAction Action { get; private set; }
	public Character Target { get; private set; }

	public void HandleEnemyAction(Character character, List<Character> allies, List<Character> opponents)
	{
		Target = null;
		_allies = allies;
		_opponents = opponents;
		_character = character;

		// Get list of available actions
		_combatActions = _character.CombatActions.ToList();

		Action = _combatActions[Random.Range(0, _combatActions.Count)];

		HandleEnemyTarget();
	}

	private void HandleEnemyTarget()
	{
		// 1. check actions
		// 2. target alley or opponent based on action type

		if (Action.TargetAllies) { TargetAlly(); }
		else { TargetOpponent(); }
	}

	private void TargetAlly()
	{
		// Heal allies with the lowest health
		// Buff unbuffed allies: prioritize higher attack

		//
		// heal
		if (Action.BehaviourTypes.Contains(ActionBehaviourType.Heal))
		{
			_allies.Sort((c1, c2) => c2.CurrentHealth - c1.CurrentHealth);
			Target = _allies[0];
		}
		// buff
		else if (Action.BehaviourTypes.Contains(ActionBehaviourType.Buff))
		{
			// TODO: add more brain cells later
			Target = _allies[Random.Range(0, _allies.Count)];
		}
		else
		{
			// target random
			Target = _allies[Random.Range(0, _allies.Count)];
		}
	}

	private void TargetOpponent()
	{
		//_target = Random.Range(0, _opponents.Count);
		// Attack: target alive opponents at random
		// Debuff: target opponents without debuff at random
		// attack
		if (Action.BehaviourTypes.Contains(ActionBehaviourType.Attack))
		{
			_opponents.Sort((c1, c2) => c2.CurrentHealth - c1.CurrentHealth);
			Target = _opponents[0];
		}
		// debuff
		else if (Action.BehaviourTypes.Contains(ActionBehaviourType.Debuff))
		{
			// TODO: add more brain cells later
			Target = _opponents[Random.Range(0, _opponents.Count)];
		}
		else
		{
			Target = _opponents[Random.Range(0, _opponents.Count)];
		}
	}
}