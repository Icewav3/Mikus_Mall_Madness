using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPosition", menuName = "PlayerPosition", order = 0)]
public class PlayerPosition : ScriptableObject
{
	private Vector2 _playerPosition;
	public Vector2 Position => _playerPosition;

	public void SetPosition(Vector2 position)
	{
		_playerPosition = position;
	}
}