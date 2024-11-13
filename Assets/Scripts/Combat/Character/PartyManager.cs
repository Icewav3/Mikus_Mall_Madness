using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Party Manager", menuName = "Characters/Party Manager")]
public class PartyManager : ScriptableObject
{
	[SerializeField]
	private List<Character> _members = new();

	public List<Character> Members => _members;

	public void HealParty()
	{
	}
}