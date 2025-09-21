using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyPatrol _enemyPatrol;
    
    private void Start()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
    }
    
    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Transform targetWaypoint = _enemyPatrol.CurrentWaypoint;
        _enemyMover.Move(targetWaypoint);
    
        if (_enemyMover.Distance <= _enemyPatrol.ReachThreshold)
        {
            _enemyPatrol.SelectNextWaypoint();
        }
    }
}
