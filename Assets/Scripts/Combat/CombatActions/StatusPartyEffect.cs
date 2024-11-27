using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Status Party Effect", menuName = "ScriptableObjects/Action Effects/Status Party Effect")]
public class StatusPartyEffect : ActionEffect
{
	[SerializeField]
	private StatusEffectBase _effectBase;
	[SerializeField]
	private int _duration = 1;

	public override void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		foreach (Character ally in allies)
		{
			if (!ally.IsDead) ally.ApplyStatus(new StatusEffect(_effectBase, _duration));
		}
	}
}