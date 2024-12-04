using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupParty : MonoBehaviour
{
	[SerializeField]
	private PartyManager _partyManager;
	[SerializeField]
	private CharacterBase _startingCharBase;

	private void Awake()
	{
		if(_partyManager.Members.Count == 0)
		{
			_partyManager.AddMember(new Character(_startingCharBase));
		}
	}
}
