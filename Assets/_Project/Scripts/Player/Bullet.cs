using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void OnObjectSpawn()
    {
        ////////////////////////////////////////////////_animator.Rebind();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            DesactiveGameObject();
            return;
        }

        OnBulletExplosion();
    }

    public void OnBulletExplosion()
    {
        PoolManager.Instance.SpawnFromPool("ExplosionEffect", transform.position, transform.rotation);
        DesactiveGameObject();
    }

    private void DesactiveGameObject()
    {
        gameObject.SetActive(false);
    }
}
