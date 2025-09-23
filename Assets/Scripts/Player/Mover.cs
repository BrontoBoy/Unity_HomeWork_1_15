using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedX  = 5;
    [SerializeField] private float _jumpForce = 6.5f;
    
    private Rigidbody2D _rigidbody;

    public float CurrentSpeed => Mathf.Abs(_rigidbody.linearVelocity.x);
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void Move(float direction)
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = _speedX * direction;
        _rigidbody.linearVelocity = velocity;
    }
    
    public void Jump()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.y = 0f;
        _rigidbody.linearVelocity = velocity;
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
    
    public float GetDistanceTo(Vector3 targetPosition)
    {
        return Vector3.Distance(transform.position, targetPosition);
    }
    
    public float GetSqrDistanceTo(Vector3 targetPosition)
    {
        return (transform.position - targetPosition).sqrMagnitude;
    }
}
