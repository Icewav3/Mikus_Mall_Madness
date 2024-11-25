using System;
using System.Collections;

using UnityEngine;

public class VisualsController : MonoBehaviour
{
	public event Action<VisualsController> OnPerformAction;
	public event Action<VisualsController> OnTurnEnd;

	[SerializeField]
	private Animator _animator;

	private Coroutine _waitRoutine;

	public void PerformAction()
	{
		OnPerformAction?.Invoke(this);
		if (_waitRoutine == null) _waitRoutine = StartCoroutine(WaitRoutine());
	}

	public void StartAnimation(ActionAnimType animType)
	{
		switch (animType)
		{
			case (ActionAnimType.Attack1):
				_animator.SetTrigger("actionDamage1");
				break;
			case (ActionAnimType.Attack2):
				_animator.SetTrigger("actionDamage2");
				break;
			case (ActionAnimType.Status):
				_animator.SetTrigger("actionStatus");
				break;
			case (ActionAnimType.Defend):
				_animator.SetTrigger("actionDefend");
				break;
			case (ActionAnimType.Signature):
				_animator.SetTrigger("actionSignature");
				break;
			default:
				return;
		}
	}
	private IEnumerator WaitRoutine()
	{
		//fuck yeah
		yield return new WaitForSeconds(1.5f);

		OnTurnEnd?.Invoke(this);

		_waitRoutine = null;
	}
}