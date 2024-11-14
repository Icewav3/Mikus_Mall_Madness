using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Base", menuName = "Characters/Character Base")]
public class CharacterBase : ScriptableObject
{
	[SerializeField]
	private int _baseHealth;
	public int BaseHealth => _baseHealth;

	[SerializeField]
	private int _baseStamina;
	public int BaseStamina => _baseStamina;

	[SerializeField]
	private int _baseSpeed;
	public int BaseSpeed => _baseSpeed;

	[SerializeField]
	private int _baseDefense;
	public int BaseDefense => _baseDefense;

	[SerializeField]
	private int _baseAttack;
	public int BaseAttack => _baseAttack;

	[SerializeField]
	private List<CombatAction> _combatActions;
	public ReadOnlyCollection<CombatAction> CombatActions => _combatActions.AsReadOnly();
}
