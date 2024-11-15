using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionEffect : ScriptableObject
{
	// all action instructions will be defined in child classes
	public abstract void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies);
}
