using UnityEngine;

namespace Player.Movement
{
    public class TransformPositionStepMovement : MonoBehaviour
    {
        [SerializeField] private float step = 1;

        private static bool ShouldMoveLeft => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        private static bool ShouldMoveRight => Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        private static bool ShouldMoveForward => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        private static bool ShouldMoveBackward => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        
        void Update()
        {
            if (ShouldMoveLeft)
                transform.position += step * Vector3.left;

            if (ShouldMoveForward)
                transform.position += step * Vector3.forward;

            if (ShouldMoveBackward)
                transform.position += step * Vector3.back;

            if (ShouldMoveRight)
                transform.position += step * Vector3.right;
        }
    }
}
