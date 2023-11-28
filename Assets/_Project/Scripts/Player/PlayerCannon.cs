using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerCannon : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField] private float _fireForce = 20f;
    [SerializeField] private float _fireRate = 1f;
    [Header("Transforms")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _frontCannon;
    [SerializeField] private Transform[] _leftSideFirePoints;
    [SerializeField] private Transform[] _rightSideFirePoints;
    [Header("Others")]
    [SerializeField] private GameObject _cannonBulletPrefab;

    private float _nextFire;

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
            GameObject bullet = Instantiate(_cannonBulletPrefab, cannonPoint.position, _playerTransform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * _fireForce, ForceMode2D.Impulse);


            FireCooldown();
        }
    }

    private void SidesFire(Transform[] firePoints, int angle)
    {
        if (Time.time > _nextFire)
        {
            foreach (var firePoint in firePoints)
            {
                GameObject bullet = Instantiate(_cannonBulletPrefab, firePoint.position,
                    Quaternion.Euler(0, 0, _playerTransform.rotation.eulerAngles.z + angle));
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * _fireForce, ForceMode2D.Impulse);
            }

            FireCooldown();
        }
    }

    private void FireCooldown()
    {
        _nextFire = Time.time + _fireRate;
    }
}
