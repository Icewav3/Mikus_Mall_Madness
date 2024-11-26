using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileEncounterTrigger : MonoBehaviour
{
	[SerializeField]
	private Encounter _encounter;
	private EncounterManager _encounterManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (_encounterManager != null)
			{
				_encounterManager.TriggerEncounter(_encounter);
			}
		}
		gameObject.SetActive(false);
	}
}
