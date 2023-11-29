using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCannon : MonoBehaviour
{
    [Header("Alterables")] 
    [SerializeField] private int _playerDamage = 1;
    [SerializeField] private float _fireForce = 20f;
    [SerializeField] private float _fireRate = 1f;
    [Header("Transforms")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _frontCannon;
    [SerializeField] private Transform[] _leftSideFirePoints;
    [SerializeField] private Transform[] _rightSideFirePoints;
    [Header("Others")] 
    [SerializeField] private GameData _gameData;
    
    private float _nextFire;

    private void Start()
    {
        _gameData.PlayerDamage = _playerDamage;
    }

    public void HandleFrontShootButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FrontFire(_frontCannon);
        }
    }

    public void HandleLeftSideShootButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SidesFire(_leftSideFirePoints, 90);
        }
    }
    
    public void HandleRightSideShootButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SidesFire(_rightSideFirePoints, -90);
        }
    }

    private void FrontFire(Transform cannonPoint)
    {
        if (Time.time > _nextFire)
        {
            GameObject bullet = PoolManager.Instance.SpawnFromPool("Bullet", cannonPoint.position, _playerTransform.rotation);
            Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(bullet.transform.up * _fireForce, ForceMode2D.Impulse);
            
            FireCooldown();
        }
    }

    private void SidesFire(Transform[] firePoints, int angle)
    {
        if (Time.time > _nextFire)
        {
            foreach (var firePoint in firePoints)
            {
                GameObject bullet = PoolManager.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.Euler(0, 0, _playerTransform.rotation.eulerAngles.z + angle));

                Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(bullet.transform.up * _fireForce, ForceMode2D.Impulse);
            }

            FireCooldown();
        }
    }

    private void FireCooldown()
    {
        _nextFire = Time.time + _fireRate;
    }
}
