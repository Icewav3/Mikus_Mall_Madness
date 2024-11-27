using UnityEngine;

[CreateAssetMenu(fileName = "Damage Proc", menuName = "ScriptableObjects/Status Effects/Procs/Damage Proc")]
public class DamageProc : StatusEffectProc
{
	[SerializeField]
	private int _damage = 1;
	[SerializeField]
	private bool _ignoreDefense = true;

	public override void Proc(Character character)
	{
		character.Damage(_damage, _ignoreDefense);
	}
}