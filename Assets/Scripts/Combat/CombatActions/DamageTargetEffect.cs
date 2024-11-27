using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Damage Target", menuName = "Action Effects/Damage Target")]
public class DamageTargetEffect : ActionEffect
{
	[SerializeField]
	private int _damage;
	[SerializeField]
	private bool _ignoreDefense = false;

	public override void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies)
	{
		target.Damage(Mathf.FloorToInt(_damage * origin.Attack), _ignoreDefense);
	}
}