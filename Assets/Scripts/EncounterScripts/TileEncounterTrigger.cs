using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileEncounterTrigger : MonoBehaviour
{
	[SerializeField]
	private Encounter _encounter;
	[SerializeField]
	private EncounterManager _encounterManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_encounter && _encounterManager)
			_encounterManager.TriggerEncounter(_encounter);
	}
}
