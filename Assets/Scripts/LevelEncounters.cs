using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "FloorEncounters", menuName = "FloorEncounters", order = 3)]
public class LevelEncounters : ScriptableObject
{
	[SerializeField] private List<Encounter> levelEncounters;

	public void ResetEncounters()
	{
		foreach (Encounter encounter in levelEncounters)
		{
			encounter.Encountered = false;
		}
	}
}