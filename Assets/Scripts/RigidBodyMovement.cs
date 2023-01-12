using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    [SerializeField] private float movementForce = 10f;
    [SerializeField] private float jumpForce = 300f;

    private Rigidbody _rigidbody;
    
    private static bool ShouldMoveLeft => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    private static bool ShouldMoveRight => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    private static bool ShouldMoveDown => Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    private static bool ShouldMoveUp => Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
    private bool _shouldJump = false; 

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_shouldJump)
            _shouldJump = Input.GetKeyDown(KeyCode.Space);
    }
    
    // false -> update bez getkeydown -> false
    // false -> update z getKeyDown -> true
    // true -> update bez getKeyDown -> true
    // fixed

    private void FixedUpdate()
    {
        if (ShouldMoveLeft)
        {
            _rigidbody.AddForce(-movementForce * transform.right);
        }
        
        if (ShouldMoveRight)
        {
            _rigidbody.AddForce(movementForce * transform.right);
        }
        
        if (ShouldMoveDown)
        {
            _rigidbody.AddForce(-movementForce * transform.forward);
        }
        
        if (ShouldMoveUp)
        {
            _rigidbody.AddForce(movementForce * transform.forward);
        }

        if (_shouldJump)
        {
            _rigidbody.AddForce(jumpForce * transform.up);
            _shouldJump = false;
        }
    }
}
