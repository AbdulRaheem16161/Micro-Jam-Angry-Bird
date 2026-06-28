using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed;

    private Rigidbody rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.forward * dashSpeed);
        }
    }
}