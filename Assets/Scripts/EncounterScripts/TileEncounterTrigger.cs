using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEncounterTrigger : MonoBehaviour
{
	public Encounter encounter;
	private EncounterManager encounterManager;

	private void Start()
	{
		encounterManager = FindObjectOfType<EncounterManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			TriggerEncounter();
		}

		gameObject.SetActive(false);
	}

	private void TriggerEncounter()
	{
		if (encounterManager != null)
		{
			encounterManager.TriggerEncounter(encounter);
		}
	}
}
