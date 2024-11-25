using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VisualsController : MonoBehaviour
{
	public event Action<VisualsController> OnPerformAction;

	public void PerformAction()
	{
		OnPerformAction?.Invoke(this);
	}
}
