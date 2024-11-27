using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float _moveSpeed = 1.0f;
	[SerializeField]
	private float _mouseDeadZone = 0.05f;

	[SerializeField]
	private Rigidbody2D _rb;

	private Vector2 _mousePos = new();
	private bool _mouseClicked = false;

	private void Update()
	{
		_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_mouseClicked = Input.GetMouseButton(0);
	}

	private void FixedUpdate()
	{
		Vector2 moveDir = (_mousePos - (Vector2)transform.position).normalized;

		if (_mouseClicked && Vector2.Distance((Vector2)_mousePos, (Vector2)transform.position) > _mouseDeadZone)
		{
			_rb.velocity = moveDir * _moveSpeed;
		}
		else
		{
			_rb.velocity = Vector2.zero;
		}
	}
}