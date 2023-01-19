using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float groundCheckRadius;

    [Header("Configuration")]
    [SerializeField]
    private float jumpForce;

    private bool _isGrounded = true;

    private bool wasButtonJumpPressed = false;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);        
    }

   
    public void OnJump(InputAction.CallbackContext value)
    {
        Debug.Log("Pressed space");

        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
        Debug.Log(_rigidbody.velocity);
    }


}
