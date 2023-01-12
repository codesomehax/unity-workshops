using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float initialJumpSpeed = 10f;
    
    private static bool ShouldMoveLeft => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    private static bool ShouldMoveRight => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    private static bool ShouldMoveDown => Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    private static bool ShouldMoveUp => Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
    
    private bool ShouldJump => Input.GetKeyDown(KeyCode.Space) && !_isJumping && IsGrounded;
    private bool IsGrounded => transform.position.y <= 1f;
    
    private float _yVelocity = 0f;
    private bool _isJumping = false;
    
    void Update()
    {
        if (ShouldMoveDown)
        {
            transform.position -= moveSpeed * Time.deltaTime * transform.forward;
        }
        
        if (ShouldMoveUp)
        {
            transform.position += moveSpeed * Time.deltaTime * transform.forward;
        }
        
        if (ShouldMoveRight)
        {
            transform.position += moveSpeed * Time.deltaTime * transform.right;
        }
        
        if (ShouldMoveLeft)
        {
            transform.position -= moveSpeed * Time.deltaTime * transform.right;
        }

        if (ShouldJump)
        {
            _yVelocity = initialJumpSpeed;
            _isJumping = true;
        }

        if (_isJumping)
        {
            transform.position += _yVelocity * Time.deltaTime * transform.up;
            _yVelocity += gravity * Time.deltaTime;

            if (IsGrounded)
            {
                _isJumping = false;
                _yVelocity = 0f;
            }
        }
    }
}
