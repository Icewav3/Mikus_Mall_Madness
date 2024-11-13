using System;
using System.Collections.Generic;

using UnityEngine;

public class CharacterActionSelector : MonoBehaviour
{
	[SerializeField]
	private CombatButtonManager _buttonManager;

	public event Action<CharacterActionSelector> OnTurnComplete;

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
	}
	private void HandleTargetSelection()
	{
	}

	private void HandleAction(CombatButtonManager buttonManager)
	{
	}
}