using System.Collections.Generic;

using UnityEngine;

///<summary>
///  Abstract base class for all action effects.
///</summary>
public abstract class ActionEffect : ScriptableObject
{
	// all action instructions will be defined in child classes
	public abstract void Activate(Character origin, Character target, List<Character> enemies, List<Character> allies);
}