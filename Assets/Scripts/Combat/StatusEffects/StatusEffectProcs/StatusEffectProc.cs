using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffectProc : ScriptableObject
{
	public abstract void Proc(Character character);
}
