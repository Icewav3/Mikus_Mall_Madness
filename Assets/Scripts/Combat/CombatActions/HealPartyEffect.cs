using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Heal Party", menuName = "Action Effects/Heal Party")]
public class HealPartyEffect : ActionEffect
{
	[SerializeField]
	private int _amount;

	public override void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		foreach (Character ally in allies)
		{
			if (!ally.IsDead) ally.Heal(_amount);
		}
	}
}