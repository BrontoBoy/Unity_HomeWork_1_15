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
        bool isRunning = direction != 0;

        if (isRunning && !_wasRunning)
        {
            _animatorHandler.PlayRun();
            _wasRunning = true;
        }
        else if (!isRunning && _wasRunning)
        {
            _animatorHandler.StopRun();
            _wasRunning = false;
        }

        if (isRunning)
        {
            _mover.Move(_inputReader.Direction);
            _spriteRotator.TryRotateTowards(direction); 
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _animatorHandler.PlayJump();
        }
    }
}