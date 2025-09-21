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
        bool isRunning = _inputReader.Direction != 0;

        if (isRunning && !_wasRunning)
        {
            _animatorHandler.ActivateRunAnimation();
            _wasRunning = true;
        }
        else if (!isRunning && _wasRunning)
        {
            _animatorHandler.DeactivateRunAnimation();
            _wasRunning = false;
        }

        if (isRunning)
        {
            _mover.Move(_inputReader.Direction);
            _spriteRotator.Rotate(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _animatorHandler.PlayJumpAnimation();
        }
    }
}