using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Self", menuName = "Action Effects/Heal Self")]
public class HealSelfEffect : ActionEffect
{
	[SerializeField]
	private int _amount;

	public override void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		origin.Heal(_amount);
	}
}
