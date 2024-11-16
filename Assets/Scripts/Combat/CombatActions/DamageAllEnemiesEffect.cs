using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage All Enemies", menuName = "Action Effects/Damage All Enemies")]
public class DamageAllEnemiesEffect : ActionEffect
{
	[SerializeField]
	private int _damage;

	public override void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		foreach(Character enemy in enemies)
		{
			if (!enemy.IsDead) enemy.Damage(Mathf.FloorToInt(_damage * origin.Attack));
		}
	}
}
