using UnityEngine;
using System;

public class CharacterActor : MonoBehaviour
{
	public event Action<CharacterActor, Character> OnInit;
	public Character Character { get; private set; }
	public void Init(Character character)
	{
		Character = character;

		OnInit?.Invoke(this, character);
	}
}