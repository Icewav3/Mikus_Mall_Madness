using System;
using UnityEngine;
using UnityEngine.Events;

public class onCollision : MonoBehaviour
{
	public UnityEvent OnCollisionDetected;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		OnCollisionDetected?.Invoke();
	}
}
