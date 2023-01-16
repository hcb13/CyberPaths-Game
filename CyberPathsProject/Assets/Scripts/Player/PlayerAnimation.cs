using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private Animator animator;

    private bool isRunning = false;

    public void OnMovement(InputAction.CallbackContext value)
    {
        float movementInput = value.ReadValue<Vector2>().magnitude;

        animator.SetBool("IsIdle", movementInput <= 0);
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

        animator.SetBool("IsRunning", isRunning);
    }
}
