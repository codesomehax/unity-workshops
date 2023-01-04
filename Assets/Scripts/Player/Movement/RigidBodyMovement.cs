using System;
using UnityEngine;

namespace Player.Movement
{
    public class RigidBodyMovement : MonoBehaviour
    {
        [SerializeField] private float movementForce = 10f;
        [SerializeField] private float jumpForce = 300f;

        private Rigidbody _rigidbody;

        private static float HorizontalMovement => Input.GetAxis("Horizontal");
        private static float VerticalMovement => Input.GetAxis("Vertical");

        private static bool ShouldMoveLeft => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        private static bool ShouldMoveRight => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        private static bool ShouldMoveForward => Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        private static bool ShouldMoveBackward => Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        private static bool JumpTrigger { get; set; }
        private bool IsGrounded => transform.position.y < 1.1f;
        

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (!JumpTrigger && IsGrounded)
                JumpTrigger = Input.GetKeyDown(KeyCode.Space);
        }

        private void FixedUpdate()
        {
            // Vector3 movementVector = new Vector3(HorizontalMovement, 0, VerticalMovement);
            //
            // _rigidbody.AddForce(movementForce * movementVector);
            
            if (ShouldMoveLeft)
                _rigidbody.AddForce(-movementForce * transform.right);
            
            if (ShouldMoveRight)
                _rigidbody.AddForce(movementForce * transform.right);
            
            if (ShouldMoveBackward)
                _rigidbody.AddForce(-movementForce * transform.forward);
            
            if (ShouldMoveForward)
                _rigidbody.AddForce(movementForce * transform.forward);

            if (JumpTrigger && IsGrounded)
            {
                JumpTrigger = false;
                _rigidbody.AddForce(jumpForce * Vector3.up);
            }
            
        }
    }
}
