using System;
using System.Collections.Generic;

using UnityEngine;

public class CombatManager : MonoBehaviour
{
	private int _turnIndex = 0;

	[SerializeField]
	private PartyManager _party;

	private List<Character> _combatants = new();
	private List<Character> _playerParty = new();
	private List<Character> _enemies = new();

	[SerializeField]
	private CharacterActionSelector _actionSelector;

	public event Action<CombatManager> OnLoopEnd;
	public event Action<CombatManager, bool> OnBattleEnd;

	private void Awake()
	{
		_actionSelector.OnTurnComplete += EndTurn;
	}
	private void OnDisable()
	{
		_actionSelector.OnTurnComplete += EndTurn;
	}

	public void InitBattle(List<Character> enemies)
	{
		_enemies = enemies;
		_playerParty = _party.Members;

		foreach (Character enemy in _enemies) _combatants.Add(enemy);
		foreach (Character ally in _playerParty) _combatants.Add(ally);

		SortCombatants();

		NextTurn();
	}

	private void SortCombatants()
	{
		_combatants.Sort((a, b) => (b.Speed - a.Speed));
	}
	private void NextTurn()
	{
	}
	private void EndLoop()
	{
		OnLoopEnd?.Invoke(this);
	}

	private void EndTurn(CharacterActionSelector actionSelector)
	{
		_turnIndex += (_combatants.Count + _turnIndex + 1) % _combatants.Count;
		if (_turnIndex == 0) EndLoop();

		NextTurn();
	}
}