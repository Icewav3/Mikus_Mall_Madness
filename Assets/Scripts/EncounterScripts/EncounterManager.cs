using System.Collections.Generic;

using UnityEngine;

public class EncounterManager : MonoBehaviour
{
	private Encounter activeEncounter; // Currently activated Encounter

	/// <summary>
	/// Enter Combat
	/// </summary>
	/// <param name="encounter"></param>
	public void TriggerEncounter(Encounter encounter)
	{
		if (activeEncounter != null)
		{
			Debug.LogWarning("An encounter is already active!");
			return;
		}
		if (encounter.GetEnemies().Count > 0 && !encounter.Encountered)
		{
			activeEncounter = encounter;
			SceneGod.SInstance.EnterCombatState(activeEncounter.GetEnemies());
		}
		else
		{
			Debug.LogWarning("There is no ENCOUNTER DATA");
		}
	}

	/// <summary>
	/// Finish Combat
	/// </summary>
	public void OnEncounterComplete()
	{
		if (SceneGod.SInstance.WonLastBattle)
		{
			//TODO::
			print("change next scene");
			activeEncounter.Encountered = true;
		}
		else
		{
			//TODO::
			print("Scene intialized");
		}
	}
}
