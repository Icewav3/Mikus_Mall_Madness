using System.Collections.Generic;

using UnityEngine;

public class EncounterManager : MonoBehaviour
{
	private Encounter _activeEncounter; // Currently activated Encounter
	[SerializeField] private LevelEncounters _levelEncounters;

	/// <summary>
	/// Enter Combat
	/// </summary>
	/// <param name="encounter"></param>
	public void TriggerEncounter(Encounter encounter)
	{
		if (_activeEncounter != null)
		{
			Debug.LogWarning("An encounter is already active!");
			return;
		}
		if (encounter.GetEnemies().Count > 0 && !encounter.Encountered)
		{
			_activeEncounter = encounter;
			SceneGod.SInstance.EnterCombatState(_activeEncounter.GetEnemies());
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
			_activeEncounter.Encountered = true;
		}
		else
		{
			//TODO::
			print("Scene intialized");
			_levelEncounters.ResetEncounters();
		}
	}
}
