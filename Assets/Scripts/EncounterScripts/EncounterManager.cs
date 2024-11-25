using System.Collections.Generic;

using UnityEngine;

public class EncounterManager : MonoBehaviour
{
	private List<Character> activeEncounter; // Currently activated Encounter

	/// <summary>
	/// Enter Combat
	/// </summary>
	/// <param name="encounter"></param>
	public void TriggerEncounter(List<Character> encounter)
	{
		if (activeEncounter != null)
		{
			Debug.LogWarning("An encounter is already active!");
			return;
		}
		if (encounter.Count > 0)
		{
			activeEncounter = encounter;
			SceneGod.SInstance.EnterCombatState(activeEncounter);
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

		}
		else
		{
			//TODO::
			print("Scene intialized");
		}
	}
}
