
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0f, 12f, -8f);

    public float smoothSpeed = 5f;

    public float rotationAngle = 55f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        Quaternion desiredRotation = Quaternion.Euler(
            rotationAngle,
            0f,
            0f
        );

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRotation,
            smoothSpeed * Time.deltaTime
        );
    }
}
