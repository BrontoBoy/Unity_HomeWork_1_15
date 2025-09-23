using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    private EnemyPatrol _patrol;
    
    private void Awake()
    {
        _patrol = GetComponent<EnemyPatrol>();
    }
    
    private void Update()
    {
        _patrol.Patrol();
    }
}