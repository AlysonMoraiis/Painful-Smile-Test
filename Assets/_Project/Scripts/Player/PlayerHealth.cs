using System;
using UnityEngine;

public class PlayerHealth : HealthController
{
    public event Action OnDestroyShip;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ChaserEnemy"))
        {
            TakeDamage(_enemyData.ChaserDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(_enemyData.ShooterDamage);
        }
    }

    protected override void DestroyShip()
    {
        base.DestroyShip();
        OnDestroyShip?.Invoke();
    }
}
