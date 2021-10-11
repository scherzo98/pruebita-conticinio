using UnityEngine;
using UnityEngine.Events;

public class Movement
{
	private float _jumpForce;                        // fuerza aplicada cuando salta
	float _speed;//Smothear el movimiento
	private Rigidbody2D _rb;
	private Transform _player;

	public Movement(Rigidbody2D rb,Transform playerT,float speed,float jumpForce)
    {
		_rb = rb;
		_player = playerT;
		_jumpForce = jumpForce;
		_speed = speed;
    }


	public void Move(Vector2 v)
    {
		_player.position += new Vector3(v.x, 0, v.y) * _speed * Time.deltaTime;
	}
  
	public void Jump()
	{
		Debug.Log("hello");
      _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
	}
	



}

