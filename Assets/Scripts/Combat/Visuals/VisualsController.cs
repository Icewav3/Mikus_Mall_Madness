using System;

using UnityEngine;

public class VisualsController : MonoBehaviour
{
	public event Action<VisualsController> OnPerformAction;

	[SerializeField]
	private Animator _animator;

	public void PerformAction()
	{
		OnPerformAction?.Invoke(this);
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
}