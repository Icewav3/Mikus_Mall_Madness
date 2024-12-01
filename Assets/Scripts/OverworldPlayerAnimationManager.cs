using UnityEngine;

public class OverworldPlayerAnimationManager : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D _rb;

	[SerializeField]
	private Animator _animator;

	private void Update()
	{
		if (_rb.velocity.magnitude != 0.0f)
		{
			_animator.SetBool("Moving", true);

			_animator.SetFloat("VelocityX", _rb.velocity.x);
			_animator.SetFloat("VelocityY", _rb.velocity.y);
		}
		else
		{
			_animator.SetBool("Moving", false);
		}
	}
}