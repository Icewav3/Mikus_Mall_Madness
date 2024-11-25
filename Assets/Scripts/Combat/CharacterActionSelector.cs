using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

///<summary>
///  <para>Class that handles selecting <see cref="CombatAction"/>s in combat.</para>
///  <para>Also handles behaviour for enemnies in combat.</para>
///</summary>
public class CharacterActionSelector : MonoBehaviour
{
	///<summary>Event called when the turn has finished and the action as been performed.</summary>
	public event Action<CharacterActionSelector> OnTurnComplete;

	[SerializeField]
	private CombatButtonManager _buttonManager;
	[SerializeField]
	private EnemyCombatAI _enemyCombatAI;

	private CombatAction _nextAction;
	private Character _target;
	private Character _currentCharacter;
	private List<Character> _allies;
	private List<Character> _opponents;
	private bool _canPickTarget = false;

	private void OnEnable()
	{
		_buttonManager.OnActionSelected += HandleAction;
	}
	private void OnDisable()
	{
		_buttonManager.OnActionSelected -= HandleAction;
	}

	///<param name="character">The character whose turn it is.</param>
	///<param name="allies">The party that the current character belongs to.</param>
	///<param name="opponents">The party that the current character does not belong to.</param>
	///<summary>
	///Starts process of selecting an action for a given <see cref="Character"/>.
	///</summary>
	public void StartSelection(Character character, List<Character> allies, List<Character> opponents)
	{
		_canPickTarget = false;
		_currentCharacter = character;
		_currentCharacter.OnActionPerformed += HandlePerformAction;
		_allies = allies;
		_opponents = opponents;
		//do different things depending on whether the character passed in is an enemy
		if (character.IsEnemy)
		{
			_enemyCombatAI.HandleEnemyAction(character, allies, opponents);
			_nextAction = _enemyCombatAI.Action;
			_target = _enemyCombatAI.Target;
			_currentCharacter.StartAnimation(_nextAction.AnimType);
		}
		else
		{
			_buttonManager.Populate(character.CombatActions.ToList());
		}
	}

	private void HandlePerformAction(Character character)
	{
		_currentCharacter.OnActionPerformed -= HandlePerformAction;
		_canPickTarget = true;
		_nextAction.Perform(_currentCharacter, _target, _opponents, _allies);
		_nextAction = null;
		OnTurnComplete?.Invoke(this);
	}
	//recieves and processes a target for the given character's chosen action
	public void HandleTargetSelection(Targetable targetable, Character target)
	{
		if (!_canPickTarget) return;

		bool validSelection =
			(_allies.Contains(target) && _nextAction.TargetAllies) ||
			(_opponents.Contains(target) && !_nextAction.TargetAllies);
		if (!validSelection) return;

		_canPickTarget = false;
		_target = target;
		_currentCharacter.StartAnimation(_nextAction.AnimType);
		_buttonManager.DeInit();
	}
	//handles the player's selected combat action
	private void HandleAction(CombatButtonManager buttonManager, CombatAction action)
	{
		_canPickTarget = true;
		_nextAction = action;
	}
}