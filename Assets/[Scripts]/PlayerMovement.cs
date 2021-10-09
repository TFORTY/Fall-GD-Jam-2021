using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    private Vector3 forwardDirection;
    private Vector3 horizontalMovement; 
    private float horizontalInput;
    public float horiSpeed = 2.0f;

    public LayerMask groundLayer;

    public float jumpForce = 7.0f;

    public CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

       if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        forwardDirection = transform.forward * speed * Time.deltaTime;
        horizontalMovement = transform.right * horizontalInput * speed * Time.deltaTime * horiSpeed;
        rb.MovePosition(rb.position + forwardDirection + horizontalMovement);
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayer);
    }
}