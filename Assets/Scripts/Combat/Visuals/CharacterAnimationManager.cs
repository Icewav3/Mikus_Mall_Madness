using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
	[SerializeField]
	private CharacterActor _target;
	private VisualsController _visuals;

	private void OnEnable()
	{
		_target.OnInit += HandleCharacterInit;
	}
	private void OnDisable()
	{
		_target.OnInit -= HandleCharacterInit;
		if(_visuals) _visuals.OnPerformAction -= HandlePerformAction;
	}

	private void HandleCharacterInit(CharacterActor actor, Character character)
	{
		_visuals = Instantiate(character.Base.Visuals, Vector3.zero, Quaternion.identity);
		_visuals.transform.SetParent(transform);
		_visuals.transform.GetChild(0).transform.position += transform.position;

		_visuals.OnPerformAction += HandlePerformAction;
	}

	private void HandlePerformAction(VisualsController visuals)
	{

	}
}