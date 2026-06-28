using UnityEngine;
using UnityEngine.InputSystem;

public class Player_movement : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float moveSpeed = 5f;
    public float dashForce = 15f;
    public float dashCooldown = 1.5f;

    private Rigidbody rb;
    private float mouseX;
    private float rotationY;
    private float moveInput;
    private float nextDashTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotationY = transform.eulerAngles.y;
    }

    void Update()
    {
        if (Mouse.current != null)
        {
            mouseX = -Mouse.current.delta.x.ReadValue();
        }
        rotationY += mouseX * rotationSpeed * Time.deltaTime;

        if (Keyboard.current != null)
        {
            moveInput = 0f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                moveInput = 1f;
            }

            if (Keyboard.current.leftShiftKey.wasPressedThisFrame && Time.time >= nextDashTime)
            {
                Dash();
            }
        }
    }

    void FixedUpdate()
    {
        Quaternion targetRotation = Quaternion.Euler(0f, rotationY, 0f);
        rb.MoveRotation(targetRotation);

        Vector3 movementDirection = transform.right * moveInput * moveSpeed;

        rb.linearVelocity = new Vector3(movementDirection.x, rb.linearVelocity.y, movementDirection.z);
    }

    void Dash()
    {
        nextDashTime = Time.time + dashCooldown;
        rb.AddForce(transform.right * dashForce, ForceMode.VelocityChange);
    }
}