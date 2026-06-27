using UnityEngine;

public class Player_jumping : MonoBehaviour
{
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform checkGroundPoint;
    public float sphereRadius = 0.2f;

    private Rigidbody rb;
    private bool jump = false;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(checkGroundPoint.position, sphereRadius, groundLayer);

        if(isGrounded)
        {
            jump = true;
        }
    }
    void FixedUpdate()
    {
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
    }
}
