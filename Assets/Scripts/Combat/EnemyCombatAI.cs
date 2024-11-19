using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.TextCore.Text;

public class EnemyCombatAI : MonoBehaviour
{
	// Handle Enemy combat turn

	// TO DO: pick an action at random
	// TO DO (later): spell check Opponent as they're all missing the second P

	// Future: add priority to certain actions
	// depending on the enemy's action selection

	private int _randomAction;
	private int _randomTarget;

	public void HandleEnemyAction(Character character, List<Character> allies, List<Character> oponents)
	{
		// Get list of available actions
		List<CombatAction> characterActions = character.CombatActions.ToList();

		_randomAction = Random.Range(0, characterActions.Count);

		HandleEnemyTarget(characterActions, _randomAction);
	}

	private void HandleEnemyTarget(List<CombatAction> characterActions, int action)
	{
		// 1. check actions

		// Future:
		// 2. Attack: target alive opponents
		// 2. Heal/Buff: target low hp/unbuffed allies
	}

	private void TargetAlly()
	{

	}

	private void TargetOponent()
	{

	}
}
