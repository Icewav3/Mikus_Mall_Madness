﻿using System.Collections.Generic;

using UnityEngine;


[CreateAssetMenu(fileName = "Encounter", menuName = "Encounter", order = 1)]
public class Encounter : ScriptableObject
{
	[SerializeField] 
	private List<CharacterBase> enemyBases;
	public bool Encountered = false;

	public List<Character> GetEnemies()
	{
		List<Character> enemies = new List<Character>();
		foreach (CharacterBase enemyBase in enemyBases)
		{
			enemies.Add(new Character(enemyBase));
		}

		return enemies;
	}
	
}