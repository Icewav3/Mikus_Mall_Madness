using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class CharacterActionSelector : MonoBehaviour
{
	public event Action<CharacterActionSelector> OnTurnComplete;

	[SerializeField]
	private CombatButtonManager _buttonManager;

	private void Awake()
	{
		_buttonManager.OnActionSelected += HandleAction;
	}
	private void OnDisable()
	{
		_buttonManager.OnActionSelected -= HandleAction;
	}

	public void StartSelection(Character character, List<Character> playerParty, List<Character> enemies)
	{
		if(character.IsEnemy)
		{

		}
		else
		{
			_buttonManager.Populate(character.CombatActions.ToArray());
		}
	}
	private void HandleTargetSelection()
	{
	}

	private void HandleAction(CombatButtonManager buttonManager, CombatAction action)
	{

	}
}