using UnityEngine;

namespace Player.Movement
{
    public class CharacterControllerSpeedMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;

        private static float HorizontalMovement => Input.GetAxis("Horizontal");
        private static float VerticalMovement => Input.GetAxis("Vertical");
        
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Vector3 inputDirection = new Vector3(HorizontalMovement, 0f, VerticalMovement);
            // Vector3 movementDirection = transform.TransformDirection(inputDirection);
            
            _characterController.SimpleMove(movementSpeed * inputDirection);
        }
    }
}
