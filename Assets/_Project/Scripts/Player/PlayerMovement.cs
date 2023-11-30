using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private float _rotationSpeed = 50;

    private Vector3 _movement;
    private Vector3 _rotation;
    
    private void FixedUpdate()
    {
        Rotation();
        Movement();
    }

    private void Rotation()
    {
        Quaternion rotation = transform.rotation;
        float anglesZ = rotation.eulerAngles.z;
        anglesZ -= _rotation.x * _rotationSpeed * Time.deltaTime;
        rotation = Quaternion.Euler(0, 0, anglesZ);
        transform.rotation = rotation;
    }

    private void Movement()
    {
        Vector3 position = transform.position;
        Vector3 velocity = new Vector3(0, _movement.y * _movementSpeed * Time.deltaTime, 0);
        position += transform.rotation * velocity;
        transform.position = position;
    }
    
    public void SetMovement(InputAction.CallbackContext value)
    {
        _movement = value.ReadValue<Vector2>();
    }
    
    public void SetRotation(InputAction.CallbackContext value)
    {
        _rotation = value.ReadValue<Vector2>();
    }
}
