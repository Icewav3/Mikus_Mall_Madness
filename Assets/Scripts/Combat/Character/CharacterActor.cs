using UnityEngine;
using System;

public class CharacterActor : MonoBehaviour
{
	[SerializeField]
	private CharacterAnimationManager _animationManager;

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

	private void HandleAnimation(Character character, ActionAnimType type)
	{
		throw new NotImplementedException();
	}
}