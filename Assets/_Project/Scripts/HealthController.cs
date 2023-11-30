using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private SpriteRenderer _shipSpriteRenderer;
    [SerializeField] private Sprite[] _stateSprite;

    [Header("Others")] 
    [SerializeField] protected GameData _gameData;

    [SerializeField] protected PoolData _poolData;

    private int _health;

    private void OnEnable()
    {
        _health = _maxHealth;
        SetShipState(0);
    }
    
    protected void TakeDamage(int value)
    {
        _health -= value;
    
        if (_health <= 0)
        {
            _health = 0;
            DestroyShip();
        }
        else if (_health <= 4)
        {
            SetShipState(2);
        }
        else if (_health <= 7)
        {
            SetShipState(1);
        }
    }

    private void SetShipState(int stateIndex)
    {
        _shipSpriteRenderer.sprite = _stateSprite[stateIndex];
    }
    
    protected virtual void DestroyShip()
    {
        PoolManager.Instance.SpawnFromPool(_poolData.Tag, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
