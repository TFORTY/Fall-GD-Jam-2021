using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    private Vector3 forwardDirection;
    private Vector3 horizontalMovement;
    private float horizontalInput;
    public float horiSpeed = 2.0f;
    public float bounceForce = 2.0f;

    public LayerMask groundLayer;

    public float jumpForce = 7.0f;

    public CapsuleCollider col;

    bool hasWon;

    bool cannotJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !cannotJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Win();

        Lose();

        Move();
    }

    void Move()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        transform.position += Vector3.right * horizontalInput * horiSpeed * Time.deltaTime;
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            hasWon = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            if (collision.contacts[0].normal.z == -1)
            {
                rb.AddForce(collision.contacts[0].normal * bounceForce, ForceMode.Impulse);
            }
        }
    }

    private void Win()
    {
        if (hasWon)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void Lose()
    {
        if (TimerText.IsTimeOut())
        {
            SceneManager.LoadScene("EndScene");
            TimerText.isTimeOut = false;
        }
    }
}