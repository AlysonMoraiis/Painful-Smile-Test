using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    
    [Header("Others")]
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private NavMeshAgent _agent;
    
    private void Start()
    {
        _agent.speed = _movementSpeed;
        _enemyData.RotationSpeed = _rotationSpeed;
    }

}
