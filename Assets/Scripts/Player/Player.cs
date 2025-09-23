using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(AnimatorHandler))]
[RequireComponent(typeof(SpriteRotator))]
public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;
    
    private InputReader _inputReader;
    private Mover _mover;
    private AnimatorHandler _animatorHandler;
    private SpriteRotator _spriteRotator;

    private bool _wasRunning = false;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _animatorHandler = GetComponent<AnimatorHandler>();
        _spriteRotator = GetComponent<SpriteRotator>();
    }

    private void FixedUpdate()
    {
        float direction = _inputReader.Direction;

        if (direction != 0 && _wasRunning == false)
        {
            _animatorHandler.PlayRun();
            _wasRunning = true;
        }
        else if (direction == 0 && _wasRunning)
        {
            _animatorHandler.StopRun();
            _wasRunning = false;
        }

        if (direction != 0)
        {
            _mover.Move(direction);
            _spriteRotator.TryRotateTowards(direction); 
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _animatorHandler.PlayJump();
        }
    }
}