using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Status Target Effect", menuName = "ScriptableObjects/Action Effects/Status Target Effect")]
public class StatusTargetEffect : ActionEffect
{
	[SerializeField]
	private StatusEffectBase _effectBase;
	[SerializeField]
	private int _duration = 1;

	public override void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		target.ApplyStatus(new StatusEffect(_effectBase, _duration));
	}
}