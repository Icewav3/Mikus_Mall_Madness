using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

///<summary>
///  Class that defines the base values to be instantiated into a <see cref="Character"/>.
///</summary>
[CreateAssetMenu(fileName = "Character Base", menuName = "Characters/Character Base")]
public class CharacterBase : ScriptableObject
{
	[SerializeField]
	private string _name;
	public string Name => _name;

	[SerializeField]
	private VisualsController _visuals;
	public VisualsController Visuals => _visuals;

	[SerializeField]
	private bool _isEnemy = false;
	public bool IsEnemy => _isEnemy;

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
	private List<CombatAction> _combatActions;
	public ReadOnlyCollection<CombatAction> CombatActions => _combatActions.AsReadOnly();
}