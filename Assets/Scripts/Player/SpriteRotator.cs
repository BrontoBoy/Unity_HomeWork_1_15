using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private const float RightAngle = 0f;
    private const float LeftAngle = 180f;
    
    private float _currentDirection = 1f;
    private Quaternion _rightRotation;
    private Quaternion _leftRotation;
    
    public bool IsFacingRight => _currentDirection > 0;
    public bool IsFacingLeft => _currentDirection < 0;
    
    private void Awake()
    {
        _rightRotation = Quaternion.Euler(0f, RightAngle, 0f);
        _leftRotation = Quaternion.Euler(0f, LeftAngle, 0f);
    }
    
    public void TryRotateTowards(float movementDirection)
    {
        if (movementDirection == 0)
        {
            return;
        }
        
        float movementSign = Mathf.Sign(movementDirection);
        
        if (NeedsRotation(movementSign))
        {
            ApplyRotation(movementSign);
        }
    }
    
    public void ForceRotate(float direction)
    {
        float directionSign = Mathf.Sign(direction);
        ApplyRotation(directionSign);
    }
    
    public void FaceRight()
    {
        ApplyRotation(1f);
    }
    
    public void FaceLeft()
    {
        ApplyRotation(-1f);
    }
    
    private bool NeedsRotation(float movementDirectionSign)
    {
        return Mathf.Sign(movementDirectionSign) != Mathf.Sign(_currentDirection);
    }
    
    private void ApplyRotation(float directionSign)
    {
        _currentDirection = directionSign;
        transform.rotation = directionSign > 0 ? _rightRotation : _leftRotation;
    }
}