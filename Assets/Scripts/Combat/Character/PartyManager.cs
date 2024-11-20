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

	public void HealParty()
	{
		foreach(Character character in _members)
		{
			character.Heal(character.MaxHealth);
		}
	}

	public void AddMember(Character member)
	{
		_members.Add(member);
	}
}