using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    
    private float _distance;
    
    public float Distance => _distance;
    
    public void Move(Transform wayPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint.position, _speed * Time.deltaTime);
        Vector3 offset = transform.position - wayPoint.position;
        _distance = offset.sqrMagnitude;
    }
}
