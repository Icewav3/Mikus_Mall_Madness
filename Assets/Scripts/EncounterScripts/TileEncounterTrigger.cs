using UnityEngine;

public class TileEncounterTrigger : MonoBehaviour
{
	[SerializeField]
	private Character[] enemyGroup;
	private EncounterManager _encounterManager;

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
		if (_encounterManager != null)
		{
			_encounterManager.TriggerEncounter(enemyGroup);
		}
	}
}
