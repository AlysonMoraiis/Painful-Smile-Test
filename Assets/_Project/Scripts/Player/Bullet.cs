using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    
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
        PoolManager.Instance.SpawnFromPool("ExplosionEffect", transform.position, transform.rotation);
        DisableGameObject();
    }

    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
