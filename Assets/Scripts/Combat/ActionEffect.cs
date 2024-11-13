using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionEffect : ScriptableObject
{
	public abstract void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies);
}
