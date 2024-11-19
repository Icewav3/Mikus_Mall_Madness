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
	///<param name="oponents">The party that the current character does not belong to.</param>
	///<summary>
	///Starts process of selecting an action for a given <see cref="Character"/>.
	///</summary>
	public void StartSelection(Character character, List<Character> allies, List<Character> oponents)
	{
		//do different things depending on whether the character passed in is an enemy
		if (character.IsEnemy)
		{
			// TODO: Define enemy behaviour
		}
		else
		{
			_buttonManager.Populate(character.CombatActions.ToArray());
		}
	}
	public void HandleTargetHover(Targetable targetable, Character character)
	{
	}
	//recieves and processes a target for the given character's chosen action
	public void HandleTargetSelection(Targetable targetable, Character character)
	{
		// TODO: Implement target selection from player
	}
	//handles the player's selected combat action
	private void HandleAction(CombatButtonManager buttonManager, CombatAction action)
	{
		// TODO: Process Action selection from player
	}
}