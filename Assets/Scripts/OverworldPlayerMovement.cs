using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f; // Movement speed of the player
	[SerializeField] private Tilemap tilemap;      // Reference to the tilemap for snapping

	private Rigidbody2D _rigidbody2D;   // Rigidbody2D component for physics-based movement
	private Vector2 _movementDirection; // Direction in which the player should move
	private bool _isMoving = false;     // Track if player is currently moving

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		ProcessInput();
	}

	private void FixedUpdate()
	{
		if (_isMoving)
		{
			MovePlayer();
		}
	}

	// Processes the input and updates movement state and direction
	private void ProcessInput()
	{
		if (Input.GetMouseButton(0))
		{
			UpdateMovementDirection();
			_isMoving = true;
		}
		else if (_isMoving)
		{
			SnapToTileCenter();
			_isMoving = false;
		}
	}

	// Updates the movement direction based on mouse position relative to the player
	private void UpdateMovementDirection()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 direction     = mousePosition - transform.position;

		// Round the direction to the nearest 45-degree angle
		if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
		{
			_movementDirection = direction.x > 0 ? new Vector2(1, 1) : new Vector2(-1, -1);
		}
		else
		{
			_movementDirection = direction.y > 0 ? new Vector2(-1, 1) : new Vector2(1, -1);
		}

		_movementDirection.Normalize();
	}

	// Moves the player in the specified direction
	private void MovePlayer()
	{
		Vector2 newPosition = _rigidbody2D.position + _movementDirection * moveSpeed * Time.fixedDeltaTime;
		_rigidbody2D.MovePosition(newPosition);
	}

	// Snaps the player to the nearest tile center on the tilemap
	private void SnapToTileCenter()
	{
		if (tilemap == null) return;
		// Convert the player’s current position to the nearest cell position in the tilemap
		Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
		// Get the world position of the center of that cell
		Vector3 cellCenter = tilemap.GetCellCenterWorld(cellPosition);
		_rigidbody2D.MovePosition(cellCenter);
	}
}