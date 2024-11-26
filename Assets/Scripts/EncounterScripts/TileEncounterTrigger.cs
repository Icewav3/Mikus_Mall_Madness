using UnityEngine;

public class TileEncounterTrigger : MonoBehaviour
{
	[SerializeField]
	private Encounter _encounter;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		SceneGod.SInstance.EnterCombatState(_encounter.GetEnemies());
	}
}