using UnityEngine;

public class EncounterManager : MonoBehaviour
{
	private Encounter _activeEncounter; // Currently activated Encounter

	[SerializeField]
	private LevelEncounters _levelEncounters;

	/// <summary>
	/// Enter Combat
	/// </summary>
	/// <param name="encounter"></param>
	public void TriggerEncounter(Encounter encounter)
	{
		Debug.Log(encounter.GetEnemies().Count);
		Debug.Log(encounter.Encountered);
		if (encounter.GetEnemies().Count > 0 && !encounter.Encountered)
		{
			Debug.Log("frog");
			_activeEncounter = encounter;
			_activeEncounter.Encountered = true;
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
	private void OnEncounterComplete()
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
			_levelEncounters.ResetEncounters();
		}
	}
}