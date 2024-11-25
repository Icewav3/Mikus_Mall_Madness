using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
	[SerializeField]
	private CharacterActor _target;

	private void OnEnable()
	{
		_target.OnInit += HandleCharacterInit;
	}
	private void OnDisable()
	{
		_target.OnInit -= HandleCharacterInit;
	}

	private void HandleCharacterInit(CharacterActor actor, Character character)
	{
		GameObject go = GameObject.Instantiate(character.Base.Visuals, Vector3.zero, Quaternion.identity);
		go.transform.SetParent(transform);
		go.transform.GetChild(0).transform.position += transform.position;
	}
}