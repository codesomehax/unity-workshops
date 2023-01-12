using UnityEngine;

public class BasicRotation : MonoBehaviour
{
    [SerializeField] private float angularVelocity = 60f;

    private static bool ShouldRotateLeft => Input.GetKey(KeyCode.Q);
    private static bool ShouldRotateRight => Input.GetKey(KeyCode.E);

    private void Update()
    {
        if (ShouldRotateLeft)
        {
            transform.rotation *= Quaternion.AngleAxis(-angularVelocity * Time.deltaTime, Vector3.up);
        }

        if (ShouldRotateRight)
        {
            transform.rotation *= Quaternion.AngleAxis(angularVelocity * Time.deltaTime, Vector3.up);
        }
    }
}