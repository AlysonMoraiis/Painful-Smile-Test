using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private PoolData _explosionEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            DisableGameObject();
            return;
        }
        
        if (other.CompareTag("Player"))
        {
            OnBulletExplosion();
        }
    }

    public void OnBulletExplosion()
    {
        PoolManager.Instance.SpawnFromPool(_explosionEffect.Tag, transform.position, transform.rotation);
        DisableGameObject();
    }

    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
