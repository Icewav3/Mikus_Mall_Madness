using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

///<summary>
///  Class that oversees the high level logic for combat.
///</summary>
public class CombatManager : MonoBehaviour
{
	//index into the combatants list that gets incremented after every turn
	//if the index exceeds the bounds of the list, it is reset and EndLoop is called
	private int _turnIndex = 0;

	[SerializeField, Tooltip("Reference to the player's party manager scriptableObject")]
	private PartyManager _party;

	//some lists of the characters involved in combat
	//playerParty and _enemies both share their contents with combatants
	private List<Character> _combatants = new();
	private List<Character> _playerParty = new();
	private List<Character> _enemies = new();

	[SerializeField]
	private CharacterActionSelector _actionSelector;

	[SerializeField]
	private List<Targetable> _targetableActors = new();

	///<summary>
	///  Event broadcast when the turn index resets to 0,
	///  meaning every character has performed a <see cref="CombatAction"/>.
	///</summary>
	public event Action<CombatManager> OnLoopEnd;
	///<summary>
	///  Event broadcast when the battle is finished.
	///  Passes a <see cref="bool"/> representing whether the player has won or not.
	///</summary>
	public event Action<CombatManager, bool> OnBattleEnd;

	private void OnEnable()
	{
		_actionSelector.OnTurnComplete += EndTurn;
	}
	private void OnDisable()
	{
		_actionSelector.OnTurnComplete -= EndTurn;
	}

	public void InitBattle(List<Character> enemies)
	{
		foreach (Targetable targetable in _targetableActors)
		{
			targetable.gameObject.SetActive(false);
		}
		_enemies = enemies;
		_playerParty = _party.Members.ToList();

		for (int i = 0; i < _enemies.Count; i++)
		{
			_targetableActors[i + 4].gameObject.SetActive(true);
			_combatants.Add(_enemies[i]);
			_targetableActors[i + 4].Actor.Init(_enemies[i]);
			_targetableActors[i + 4].OnSelect += _actionSelector.HandleTargetSelection;
		}
		for (int i = 0; i < _playerParty.Count; i++)
		{
			_targetableActors[i].gameObject.SetActive(true);
			_combatants.Add(_playerParty[i]);
			_targetableActors[i].Actor.Init(_playerParty[i]);
			_targetableActors[i].OnSelect += _actionSelector.HandleTargetSelection;
		}

		SortCombatants();

		NextTurn();
	}
	public void EndBattle(bool victory)
	{
		for (int i = 0; i < _enemies.Count; i++)
		{
			_targetableActors[i + 4].OnSelect -= _actionSelector.HandleTargetSelection;
		}
		for (int i = 0; i < _playerParty.Count; i++)
		{
			_targetableActors[i].OnSelect -= _actionSelector.HandleTargetSelection;
		}
		SceneGod.SInstance.EnterExploreState(victory);
	}

	//sorts the combatants based on their individual speed stats
	//a higher speed stat means the character will have a lower index
	private void SortCombatants()
	{
		_combatants.Sort((a, b) => (b.Speed - a.Speed));
	}

	//handles starting a turn loop
	private void NextTurn()
	{
		Character nextCharacter = _combatants[_turnIndex];

		if (nextCharacter.IsDead)
		{
			EndTurn(_actionSelector);
			return;
		}

		if (nextCharacter.IsEnemy)
		{
			_actionSelector.StartSelection(nextCharacter, _enemies, _playerParty);
		}
		else
		{
			_actionSelector.StartSelection(nextCharacter, _playerParty, _enemies);
		}
	}
	//callback that listens to an event on the character action selector
	//marks the end of a turn loop
	private void EndTurn(CharacterActionSelector actionSelector)
	{
		//increment the turn index
		//if the index is outside the bounds of the combatants list, wrap it with the modulus operator
		_turnIndex = (_combatants.Count + _turnIndex + 1) % _combatants.Count;
		//if the turn index is 0 after incrementing
		//this means the manager has done a full cycle through every combatant
		//call the end cycle method
		if (_turnIndex == 0) EndCombatCycle();

		if (_playerParty.FirstOrDefault(c => !c.IsDead) == null)
		{
			EndBattle(false);
		}
		else if (_enemies.FirstOrDefault(c => !c.IsDead) == null)
		{
			EndBattle(true);
		}
		else
		{
			//restart the loop
			NextTurn();
		}
	}
	//marks the end of a full cycle through every combatant on the field
	private void EndCombatCycle()
	{
		// NOTE: We might want more functionality here later
		OnLoopEnd?.Invoke(this);
	}
}