using UnityEngine;

public class ChaserEnemyHealth : HealthController
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(_gameData.PlayerDamage);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PoolManager.Instance.SpawnFromPool(_poolData.Tag, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
