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

	private CombatAction _nextAction;
	private Character _currentCharacter;
	private List<Character> _allies;
	private List<Character> _opponents;

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
		_currentCharacter = character;
		_allies = allies;
		_opponents = opponents;
		//do different things depending on whether the character passed in is an enemy
		if (character.IsEnemy)
		{
			//TEST PLEASE REMOVE
			character.CombatActions[UnityEngine.Random.Range(0, character.CombatActions.Count)]
			.Perform(character, opponents[0], opponents, allies);
			OnTurnComplete?.Invoke(this);
			print("Enemy HP: " + character.CurrentHealth);
			// TODO: Define enemy behaviour
		}
		else
		{
			_buttonManager.Populate(character.CombatActions.ToList());
		}
	}
	public void HandleTargetHover(Targetable targetable, Character character)
	{
	}
	//recieves and processes a target for the given character's chosen action
	public void HandleTargetSelection(Targetable targetable, Character target)
	{
		_nextAction.Perform(_currentCharacter, target, _opponents, _allies);
		OnTurnComplete?.Invoke(this);
		print("Player Character HP: " + _currentCharacter.CurrentHealth);
	}
	//handles the player's selected combat action
	private void HandleAction(CombatButtonManager buttonManager, CombatAction action)
	{
		_nextAction = action;
	}
}