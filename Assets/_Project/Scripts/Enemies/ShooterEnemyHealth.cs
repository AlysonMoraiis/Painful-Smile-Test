using UnityEngine;

public class ShooterEnemyHealth : HealthController
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(_gameData.PlayerDamage);
        }
    }
    
    protected override void DestroyShip()
    {
        base.DestroyShip();
        _gameData.Points += 1;
    }
}
