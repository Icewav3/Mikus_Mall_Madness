using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDamageNumbers : MonoBehaviour
{
	[SerializeField]
	private CharacterActor _actor;
	[SerializeField]
	private Color _damageColor;
	[SerializeField]
	private Color _healColor;
	[SerializeField]
	private DamageNumber _damageNumberObj;

	private void OnEnable()
	{
		_actor.OnInit += HandleInit;
	}

	private void OnDisable()
	{
		_actor.OnInit -= HandleInit;
		if (_actor.Character != null)
		{
			_actor.Character.OnDamage -= SpawnDamageNumber;
			_actor.Character.OnHeal -= SpawnHealNumber;
		}
	}

	private void HandleInit(CharacterActor actor, Character character)
	{
		_actor.Character.OnDamage += SpawnDamageNumber;
		_actor.Character.OnHeal += SpawnHealNumber;
	}

	private void SpawnDamageNumber(Character character, DamageEvent dmgEvent)
	{
		DamageNumber dmgNum = Instantiate(_damageNumberObj, _actor.transform.position, Quaternion.identity);
		dmgNum.Text.color = _damageColor;
		dmgNum.Text.text = $"-{dmgEvent.AppliedDamage}";
	}

	private void SpawnHealNumber(Character character, int heal)
	{
		DamageNumber dmgNum = Instantiate(_damageNumberObj, _actor.transform.position, Quaternion.identity);
		dmgNum.Text.color = _healColor;
		dmgNum.Text.text = $"+{heal}";
	}
}
