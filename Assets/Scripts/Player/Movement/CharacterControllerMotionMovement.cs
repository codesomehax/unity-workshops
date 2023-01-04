using System;
using UnityEngine;

namespace Player.Movement
{
    public class CharacterControllerMotionMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float jumpSpeed = 0.5f;
        [SerializeField] private float gravity = 2f;

        private static float HorizontalMovement => Input.GetAxis("Horizontal");
        private static float VerticalMovement => Input.GetAxis("Vertical");

        private bool ShouldJump { get; set; }
        
        private CharacterController _characterController;

        private Vector3 _currentMovement;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            ShouldJump = _characterController.isGrounded && Input.GetKey(KeyCode.Space);
        }

        private void FixedUpdate()
        {
            Vector3 inputDirection = new Vector3(HorizontalMovement, 0f, VerticalMovement);
            Vector3 movementDirection = transform.TransformDirection(inputDirection);
            Vector3 dMovement = movementSpeed * Time.fixedDeltaTime * movementDirection;
            
            _currentMovement.Set(dMovement.x, _currentMovement.y, dMovement.z);
            
            if (ShouldJump)
            {
                _currentMovement.y = jumpSpeed;
            }
            else if (_characterController.isGrounded)
            {
                _currentMovement.y = 0f;
            }
            else
            {
                _currentMovement.y -= gravity * Time.fixedDeltaTime;
            }
            
            _characterController.Move(_currentMovement);
        }
    }
}