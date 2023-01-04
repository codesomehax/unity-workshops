using UnityEngine;

namespace Player.Rotation
{
    public class MouseRotation : MonoBehaviour
    {
        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitSomething = Physics.Raycast(ray, out RaycastHit hitInfo);

            if (hitSomething)
            {
                Vector3 aimedDirection = hitInfo.point;
                transform.LookAt(new Vector3(aimedDirection.x, transform.position.y, aimedDirection.z));
            }
        }
    }
}