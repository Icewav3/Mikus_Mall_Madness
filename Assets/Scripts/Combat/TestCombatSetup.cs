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
        Character party = new Character(_partyBase);
        Character enemy = new Character(_enemyBase);

		_partyManager.Clear();
        _partyManager.AddMember(party);

        _combatManager.InitBattle(new List<Character>() { enemy });
    }
}