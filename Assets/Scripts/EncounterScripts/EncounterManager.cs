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
	/// <param name="outcome">true victory</param>
	public void OnEncounterComplete(bool outcome)
	{
		if (activeEncounter == null)
		{
			Debug.LogWarning("No active encounter to complete.");
			return;
		}

		if (outcome) // victory
		{
			HandleVictory();
		}
		else
		{
			HandleDefeat();
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
