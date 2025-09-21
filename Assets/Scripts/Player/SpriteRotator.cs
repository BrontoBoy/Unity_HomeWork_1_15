using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private const float RightAngle = 0f;
    private const float LeftAngle = 180f;
    
    private float _lastDirection = 1f;
    private Quaternion _rightRotation;
    private Quaternion _leftRotation;
    
    private void Awake()
    {
        _rightRotation = Quaternion.Euler(0f, RightAngle, 0f);
        _leftRotation = Quaternion.Euler(0f, LeftAngle, 0f);
    }
    
    public void Rotate(float direction)
    {
        if (direction == 0)
        {
            return;
        }
        
        if (Mathf.Sign(direction) != Mathf.Sign(_lastDirection))
        {
            _lastDirection = Mathf.Sign(direction);
            transform.rotation = _lastDirection > 0 ? _rightRotation : _leftRotation;
        }
    }
}