using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    
    private void Start()
    {
        _agent.speed = _movementSpeed;
        _enemyData.RotationSpeed = _rotationSpeed;
    }

}
