using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

using UnityEngine;

public class EnemyCombatAI : MonoBehaviour
{
	// Handle Enemy combat turn

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

		// Action = _combatActions[Random.Range(0, _combatActions.Count)];

		/*
		 * Thoughts:
		 * - Replace the hardcoded action selection with something more flexible
		 * - Signatures stamina cost are more than the max stamina of the character
		 *	 so that needs some tuning so for now the enemy can only attack or heal/buff
		 */

		// WIP here:
		// check each ally
		for (int ally = 0; ally < _allies.Count; ally++)
		{
			// get combatActions index
			for (int i = 0; i < _combatActions.Count; i++)
			{
				// check if any ally has low hp - %30 or less
				if (_allies[ally].CurrentHealth < _allies[ally].MaxHealth * 0.3)
				{
					// heal
					Action = _combatActions[1];
					Debug.Log("HEALING/BUFFING");
				}
				/*else if (_character.CurrentStamina >= 60)
				{
				// signature
					Action = _combatActions[2];
					Debug.Log("SIGNATURE");
				}*/
				else
				{
					// reg attack
					Action = _combatActions[0];
					Debug.Log("ATTACK");
				}
			}
		}

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