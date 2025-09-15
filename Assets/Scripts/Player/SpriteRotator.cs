using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private float _lastDirection = 1f;

    public void Rotate(float direction)
    {
        if (direction != 0)
        {
            _lastDirection = direction;
        }

        transform.rotation = Quaternion.Euler(0f, _lastDirection > 0 ? 0f : 180f, 0f);
    }
}