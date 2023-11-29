using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthController
{
    public event Action OnDestroyShip;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ChaserEnemy"))
        {
            TakeDamage(_gameData.ChaserDamage);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(_gameData.ChaserDamage);
        }
    }

    protected override void DestroyShip()
    {
        PoolManager.Instance.SpawnFromPool("ExplosionEffect", transform.position, transform.rotation);
        OnDestroyShip?.Invoke();
    }
}
