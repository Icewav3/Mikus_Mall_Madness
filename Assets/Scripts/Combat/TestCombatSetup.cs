using System.Collections.Generic;

using UnityEngine;

public class TestCombatSetup : MonoBehaviour
{
	[SerializeField]
	private PartyManager _partyManager;

	[SerializeField]
	private CharacterBase _partyBase;
	[SerializeField]
	private CharacterBase _enemyBase;

	[SerializeField]
	private CombatManager _combatManager;

	private void OnEnable()
	{
		Character party1 = new(_partyBase);
		Character party2 = new(_partyBase);
		Character party3 = new(_partyBase);
		Character enemy1 = new(_enemyBase);
		Character enemy2 = new(_enemyBase);
		Character enemy3 = new(_enemyBase);
		Character enemy4 = new(_enemyBase);

		_partyManager.Clear();
		_partyManager.AddMember(party1);
		_partyManager.AddMember(party2);
		_partyManager.AddMember(party3);

		_combatManager.InitBattle(new List<Character>() { enemy1, enemy2, enemy3, enemy4 });
	}
}