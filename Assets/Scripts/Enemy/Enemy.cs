using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _reachThreshold = 0.1f;
    
    private int _currentWaypointIndex = 0;
    private void Start()
    {
        if (_waypoints == null || _waypoints.Length == 0)
        {
            enabled = false;
        }
        
        _reachThreshold *= _reachThreshold;
    }
    
    private void Update()
    {
        MoveToWaypoint();
    }
    
    private void MoveToWaypoint()
    {
        Transform currentWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);
        Vector3 offset = transform.position - currentWaypoint.position;
        float distance = offset.sqrMagnitude;
        
        if (distance <= _reachThreshold)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }
    }
}
