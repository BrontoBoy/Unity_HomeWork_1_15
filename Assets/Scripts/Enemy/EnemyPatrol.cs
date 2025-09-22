using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _reachThreshold = 0.1f;
    [SerializeField] private float _stuckThreshold = 2f; 
    
    private int _currentWaypointIndex = 0;
    private Vector3 _lastPosition;
    private float _stuckTimer = 0f;
    
    public Transform CurrentWaypoint => _waypoints[_currentWaypointIndex];
    
    private void Start()
    {
        if (_waypoints == null || _waypoints.Length == 0)
        {
            enabled = false;
        }
        
        _lastPosition = transform.position;
    }

    public void Patrol(Mover mover)
    {
        float direction = GetDirectionToWaypoint();
        mover.Move(direction);
        
        if (IsStuck())
        {
            SelectNextWaypoint();
            _stuckTimer = 0f;
        }
        
        if (HasReachedWaypoint())
        {
            SelectNextWaypoint(); 
        }
        
        _lastPosition = transform.position;
    }
    
    public void SelectNextWaypoint()
    {
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
    }
    
    private float GetDirectionToWaypoint()
    {
        Vector2 direction = CurrentWaypoint.position - transform.position;
        
        return Mathf.Sign(direction.x);
    }
    
    private bool HasReachedWaypoint()
    {
        float sqrDistance = (CurrentWaypoint.position - transform.position).sqrMagnitude;
        
        return sqrDistance <= _reachThreshold * _reachThreshold;
    }
    
    private bool IsStuck()
    {
        float distanceMoved = Mathf.Abs(transform.position.x - _lastPosition.x);
        
        if (distanceMoved < 0.01f)
        {
            _stuckTimer += Time.deltaTime;
            
            return _stuckTimer >= _stuckThreshold;
        }
        else
        {
            _stuckTimer = 0f; 
            
            return false;
        }
    }
}