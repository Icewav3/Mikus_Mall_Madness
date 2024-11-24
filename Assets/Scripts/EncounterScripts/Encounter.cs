using UnityEngine;

public class Encounter : MonoBehaviour 
{
	[SerializeField]
	private GameObject[] enemyGroup;

	public void StartEncounter()
	{
		Debug.Log("StartEncounter");
	}
}
