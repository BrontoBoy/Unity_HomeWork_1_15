using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _reachThreshold = 0.1f;
    
    private int _currentWaypointIndex = 0;
    
    public Transform CurrentWaypoint => _waypoints[_currentWaypointIndex];
    public float ReachThreshold => _reachThreshold;
    
    private void Start()
    {
        if (_waypoints == null || _waypoints.Length == 0)
        {
            enabled = false;
        }
        
        _reachThreshold *= _reachThreshold;
    }

    public void SelectNextWaypoint()
    {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
    }
}
