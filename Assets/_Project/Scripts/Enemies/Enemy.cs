using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _rotationSpeed;
    [SerializeField] protected float _fireForce;
    [SerializeField] protected float _fireRate;
}
