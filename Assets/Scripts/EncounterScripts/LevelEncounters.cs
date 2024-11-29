using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "FloorEncounters", menuName = "FloorEncounters", order = 3)]
public class LevelEncounters : ScriptableObject
{
	[SerializeField] 
	private List<Encounter> _levelEncounters;

	public void ResetEncounters()
	{
		foreach (Encounter encounter in _levelEncounters)
		{
			encounter.Encountered = false;
		}
	}
}