using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
	[SerializeField] private float _JumpForce = 10f;                          // fuerza aplicada cuando salta
	[SerializeField] float _speed = 10f; //Smothear el movimiento
	bool isGrounded = false;
	[SerializeField]
	public Transform isGroundedChecker;
	[SerializeField]
	public float checkGroundRadius;
	[SerializeField]
	public LayerMask groundLayer;

	private Rigidbody2D _rb;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.


	




	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();

		
	}
	void Move()
    {
		float x = Input.GetAxisRaw("Horizontal");
		float moveBy = x * _speed;
		_rb.velocity = new Vector2(moveBy, _rb.velocity.y);
    }
    private void Update()
    {
		Move();
		CheckIfGrounded();
		Jump();
		Debug.Log(transform.position);
    }
	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space )&& isGrounded)
			_rb.velocity = new Vector2(_rb.velocity.x, _JumpForce);
	}
	void CheckIfGrounded()
	{
		Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
		Debug.Log(collider);
		if (collider != null)
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}



}

