using UnityEngine;

public class TileEncounterTrigger : MonoBehaviour
{
	[SerializeField]
	private Encounter _encounter;
	[SerializeField]
	private EncounterManager _encounterManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.gameObject.CompareTag("Player")) return;
		if (_encounter && _encounterManager)
		{
			_encounterManager.TriggerEncounter(_encounter);
			this.gameObject.SetActive(false);
		}
	}
}