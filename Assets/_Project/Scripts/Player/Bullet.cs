using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private PoolData _explosionEffect;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            DisableGameObject();
            return;
        }

        OnBulletExplosion();
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
