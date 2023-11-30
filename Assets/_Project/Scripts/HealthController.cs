using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private SpriteRenderer _shipSpriteRenderer;
    [SerializeField] private Sprite[] _stateSprite;
    
    [Header("Health Bar")]
    [SerializeField] private GameObject _healthCanvas;
    [SerializeField] private Image _healthBar;
    private int _health;

    [Header("Others")] 
    [SerializeField] protected GameData _gameData;
    [SerializeField] protected PoolData _poolData;


    private void OnEnable()
    {
        _health = _maxHealth;
        SetShipState(0);
        UpdateHealthBar();
    }
    
    protected void TakeDamage(int value)
    {
        _health -= value;
        
        UpdateHealthBar();
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

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = (float)_health / _maxHealth;
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
    
    private void Update()
    {
        _healthCanvas.transform.rotation = Quaternion.identity;
    }
}
