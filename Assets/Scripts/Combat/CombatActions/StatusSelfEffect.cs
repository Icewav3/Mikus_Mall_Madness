using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Status Self Effect", menuName = "ScriptableObjects/Action Effects/Status Self Effect")]
public class StatusSelfEffect : ActionEffect
{
	[SerializeField]
	private StatusEffectBase _effectBase;
	[SerializeField]
	private int _duration = 1;

	public override void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		origin.ApplyStatus(new StatusEffect(_effectBase, _duration));
	}
}