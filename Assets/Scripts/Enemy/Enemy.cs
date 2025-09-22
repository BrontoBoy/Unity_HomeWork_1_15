using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(EnemyPatrol))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private EnemyPatrol _patrol;
    
    private void Start()
    {
        _mover = GetComponent<Mover>();
        _patrol = GetComponent<EnemyPatrol>();
    }
    
    private void Update()
    {
        _patrol.Patrol(_mover);
    }
}