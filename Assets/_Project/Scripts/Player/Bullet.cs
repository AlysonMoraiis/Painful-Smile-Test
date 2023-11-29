using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void Awake()
    {
        Invoke("OnBulletExplosion", 10f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            OnBulletExplosion();
            return;
        }
        
        _animator.SetTrigger("Explosion");
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }

    public void OnBulletExplosion()
    {
        //colocar object pooling      ///////////////////////////////////////////////////////
        Destroy(gameObject);
    }
}
