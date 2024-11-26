using UnityEngine;
using UnityEngine.Tilemaps;
public class CollisionController : MonoBehaviour
{
	private TilemapRenderer _tilemapRenderer;

	[SerializeField]
	private bool _showCollision = false;

	// Start is called before the first frame update
	private void Start()
	{
		_tilemapRenderer = GetComponent<TilemapRenderer>();
		_tilemapRenderer.enabled = _showCollision;
	}
}