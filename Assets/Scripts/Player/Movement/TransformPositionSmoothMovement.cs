using System.Collections;
using UnityEngine;

namespace Player.Movement
{
    public class TransformPositionSmoothMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5;

        private static bool ShouldMoveLeft => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        private static bool ShouldMoveRight => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        private static bool ShouldMoveForward => Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        private static bool ShouldMoveBackward => Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        
        void Update()
        {
            Transform tf = transform;
            
            if (ShouldMoveLeft)
                tf.position -= Time.deltaTime * moveSpeed * tf.right;
            
            if (ShouldMoveRight)
                tf.position += Time.deltaTime * moveSpeed * tf.right;
            
            if (ShouldMoveForward)
                tf.position += Time.deltaTime * moveSpeed * tf.forward;
            
            if (ShouldMoveBackward)
                tf.position -= Time.deltaTime * moveSpeed * tf.forward;
        }
    }
}
