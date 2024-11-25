using UnityEngine;

public class RenderHealthBar : MonoBehaviour
{
	[SerializeField]
	private CharacterActor _actor;
	[SerializeField]
	private SpriteRenderer _healthBar;
	[SerializeField]
	private Gradient _colorOverHealth;

	private void OnEnable()
	{
		_actor.OnInit += HandleInit;
		if (_healthBar.drawMode != SpriteDrawMode.Tiled) Debug.LogWarning("A Health bar does not have its draw mode set to tiled. Attempting to fix");
		_healthBar.drawMode = SpriteDrawMode.Tiled;
	}

	private void OnDisable()
	{
		_actor.OnInit -= HandleInit;
		if (_actor.Character != null)
		{
			_actor.Character.OnDamage -= DepleteHealthBar;
			_actor.Character.OnHeal -= ReplenishHealthBar;
		}
	}

	private void HandleInit(CharacterActor actor, Character character)
	{
		_actor.Character.OnDamage += DepleteHealthBar;
		_actor.Character.OnHeal += ReplenishHealthBar;

		UpdateHealthBar(_actor.Character);
	}

	private void DepleteHealthBar(Character character, DamageEvent damageEvent)
	{
		UpdateHealthBar(character);
	}

	private void ReplenishHealthBar(Character character, int heal)
	{
		UpdateHealthBar(character);
	}

	private void UpdateHealthBar(Character character)
	{
		float hpPercentage = (float)character.CurrentHealth / (float)character.MaxHealth;

		_healthBar.size = new Vector2(hpPercentage, 1);

		_healthBar.color = _colorOverHealth.Evaluate(hpPercentage);
	}
}