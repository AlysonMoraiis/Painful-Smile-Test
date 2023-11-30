using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCannon : MonoBehaviour
{
    [SerializeField] private float _fireForce;
    [SerializeField] private float _fireRate;
    [SerializeField] private Transform _thisTransform;
    [SerializeField] private Transform _frontCannon;
    [SerializeField] private PoolData _bulletPool;
    
    private bool _canShoot = true;
    
    private void Start()
    {
        StartCoroutine(FrontShoot(_fireRate));
    }

    private IEnumerator FrontShoot(float value)
    {
        while (_canShoot)
        {
            yield return new WaitForSeconds(value);
        
            GameObject bullet = PoolManager.Instance.SpawnFromPool(_bulletPool.Tag, _frontCannon.position, _frontCannon.rotation);
            Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(bullet.transform.up * _fireForce, ForceMode2D.Impulse);   
        }
    }
}
