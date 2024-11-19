using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Targetable : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
	[SerializeField]
	private CharacterActor _actor;
	public CharacterActor Actor => _actor;

	public event Action<Targetable, Character> OnSelect;
	public event Action<Targetable, Character> OnHover;

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		if (_actor.Character.IsDead) return;
		OnHover?.Invoke(this, _actor.Character);
	}
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (_actor.Character.IsDead) return;
		OnSelect?.Invoke(this, _actor.Character);
	}
}