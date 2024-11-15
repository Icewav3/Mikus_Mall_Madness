using System;

using UnityEngine;

public class CombatButtonManager : MonoBehaviour
{
	public event Action<CombatButtonManager, CombatAction> OnActionSelected;

	public void Populate(CombatAction[] combatActions)
	{
	}
	public void DeInit()
	{
	}
}