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
		SceneGod.SInstance.EnterCombatState(_encounter.GetEnemies());
	}
}
