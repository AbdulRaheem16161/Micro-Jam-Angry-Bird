using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Distance")]
    [SerializeField] private float distance = 6f;
    [SerializeField] private float height = 2f;

    [Header("Rotation")]
    [SerializeField] private float sensitivity = 200f;
    [SerializeField] private float minPitch = -20f;
    [SerializeField] private float maxPitch = 70f;

    [Header("Follow")]
    [SerializeField] private float followSmoothness = 12f;

    private float yaw;
    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = transform.eulerAngles.y;
        pitch = 15f;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 desiredPosition =
            target.position
            - rotation * Vector3.forward * distance
            + Vector3.up * height;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSmoothness * Time.deltaTime);

        transform.LookAt(target.position + Vector3.up * height);
    }
}