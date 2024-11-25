using System;

using UnityEngine;

public class CharacterActor : MonoBehaviour
{
	public event Action<CharacterActor, ActionAnimType> OnAnimationStart;
	public event Action<CharacterActor, Character> OnInit;
	public Character Character { get; private set; }

	private void OnDisable()
	{
		if (Character != null)
		{
			Character.OnAnimationStart -= HandleAnimation;
		}
	}

	public void Init(Character character)
	{
		Character = character;
		Character.OnAnimationStart += HandleAnimation;

		OnInit?.Invoke(this, character);
	}

	private void HandleAnimation(Character character, ActionAnimType animType)
	{
		OnAnimationStart?.Invoke(this, animType);
	}

	public void PerformAction()
	{
		Character.PerformAction();
	}
}