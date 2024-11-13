using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;       // Movement speed of the player
        [SerializeField] private Tilemap tilemap;            // Reference to the tilemap for snapping
        
        private Vector2 _movementDirection; // Direction in which the player should move
        private bool _isMoving = false;     // Track if player is currently moving
        
        private void Update()
        {
            ProcessInput();
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
            Vector2 direction = mousePosition - transform.position;

            // Round the direction to the nearest 45-degree angle
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                _movementDirection = direction.x > 0 ? Vector2.right + Vector2.up : Vector2.left + Vector2.down;
            }
            else
            {
                _movementDirection = direction.y > 0 ? Vector2.up + Vector2.left : Vector2.down + Vector2.right;
            }
            _movementDirection.Normalize();
        }

        // Moves the player in the specified direction
        private void MovePlayer()
        {
            Vector2 newPosition = (Vector2)transform.position + _movementDirection * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        // Snaps the player to the nearest tile center on the tilemap
        private void SnapToTileCenter()
        {
            if (tilemap == null) return;
            // Convert the player’s current position to the nearest cell position in the tilemap
            Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
            // Get the world position of the center of that cell
            Vector3 cellCenter = tilemap.GetCellCenterWorld(cellPosition);
            transform.position = cellCenter;
        }
    }
}