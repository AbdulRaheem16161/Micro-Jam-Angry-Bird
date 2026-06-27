using UnityEngine;

public class Player_jumping : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpCooldownTime = 0f;
    public LayerMask groundLayer;
    public Transform checkGroundPoint;
    public float sphereRadius = 0.2f;

    private Rigidbody rb;
    private bool jump = false;
    private float jumpCooldown = 0f;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(checkGroundPoint.position, sphereRadius, groundLayer);

        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }
        else if(jumpCooldown <= 0 && isGrounded)
        {
            jump = true;
            jumpCooldown = jumpCooldownTime;
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
    void OnDrawGizmosSelected()
    {
        if (checkGroundPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(checkGroundPoint.position, sphereRadius);
        }
    }
}
