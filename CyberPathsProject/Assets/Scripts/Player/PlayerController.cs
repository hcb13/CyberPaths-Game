using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedRun;

    [Header("Dependencies")]
    [SerializeField]
    private Rigidbody2D _rigidbody;

    private Vector2 _movementInput;
    private bool isRunning = false;

    private void FixedUpdate()
    {
        if (isRunning)
        {
            _rigidbody.velocity = _movementInput * speedRun;
        }
        else
        {
            _rigidbody.velocity = _movementInput * speed;
        }
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movementInput = value.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext value)
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            isRunning = true;
        }
        else if (Keyboard.current.xKey.wasReleasedThisFrame) 
        {
            isRunning = false;
        }
    }
}
