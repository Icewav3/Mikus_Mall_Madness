using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EncounterOutcome
{
	Victory,
	Defeat
}

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
		if (encounter)
		{
			activeEncounter = encounter;
			activeEncounter.StartEncounter();
		}
		else
		{
			Debug.LogWarning("There is no ENCOUNTER DATA");
		}
	}

	/// <summary>
	/// Finish Combat
	/// </summary>
	/// <param name="outcome"></param>
	public void OnEncounterComplete(EncounterOutcome outcome)
	{
		if (activeEncounter == null)
		{
			Debug.LogWarning("No active encounter to complete.");
			return;
		}

		switch (outcome)
		{
			case EncounterOutcome.Victory:
				HandleVictory();
				break;
			case EncounterOutcome.Defeat:
				HandleDefeat();
				break;
		}
		activeEncounter = null;
	}

	/// <summary>
	/// Victory
	/// </summary>
	private void HandleVictory()
	{
		Debug.Log("Player won the encounter!");
	}

	/// <summary>
	/// Defeat
	/// </summary>
	private void HandleDefeat()
	{
		Debug.Log("Player lost the encounter!");
	}
}
