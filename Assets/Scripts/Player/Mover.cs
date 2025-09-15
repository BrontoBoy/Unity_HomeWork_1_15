using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedX  = 5;
    [SerializeField] private float _jumpForce = 6.5f;
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void Move(float direction)
    {
        _rigidbody.linearVelocity = new Vector2(_speedX * direction, _rigidbody.linearVelocity.y);
    }
    
    public void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}
