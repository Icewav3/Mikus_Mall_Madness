using UnityEngine;

[CreateAssetMenu(fileName = "Heal Proc", menuName = "ScriptableObjects/Status Effects/Procs/Heal Proc")]
public class HealProc : StatusEffectProc
{
	[SerializeField]
	private int _heal = 1;

	public override void Proc(Character character)
	{
		character.Heal(_heal);
	}
}