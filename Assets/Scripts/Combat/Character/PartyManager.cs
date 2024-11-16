using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;

[CreateAssetMenu(fileName = "Party Manager", menuName = "Characters/Party Manager")]
public class PartyManager : ScriptableObject
{
	[SerializeField]
	private List<Character> _members = new();

	// only publicly expose as read only so no other classes can add/remove members from our party
	public ReadOnlyCollection<Character> Members => _members.AsReadOnly();

	///<summary>
	///  Iterates through the entire party to reset their health and other stats to default.
	///</summary>
	public void HealParty()
	{
		foreach (Character character in _members)
		{
			character.Heal(character.MaxHealth);
		}
	}

	///<param name="member">The <see cref="Character"/> to be added.</param>
	///<summary>Adds a <see cref="Character"/> to the party.</summary>
	public void AddMember(Character member)
	{
		_members.Add(member);
	}
}