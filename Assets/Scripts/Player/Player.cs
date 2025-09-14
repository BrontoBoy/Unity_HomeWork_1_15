using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);
    
    [SerializeField] private float _moveSpeed =  5f;
    [SerializeField] private float _jumpForce = 6.5f;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isMoving;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        string animatorIsMove = "isMove";
        float direction = Input.GetAxis(Horizontal);
        float movement = direction * _moveSpeed * Time.deltaTime;
        float jump = Input.GetAxis(Jump);
        float jumpForce = jump * _jumpForce * Time.deltaTime;
        transform.Translate(movement * Vector2.right);
        transform.Translate(jumpForce * Vector2.up);
        _isMoving = Mathf.Abs(direction) > 0.1f;
        _animator.SetBool(animatorIsMove, _isMoving);
        
        if (direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
