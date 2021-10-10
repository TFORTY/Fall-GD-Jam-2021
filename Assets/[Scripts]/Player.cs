using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float startSpeed = 5.0f;
    [SerializeField] float horiSpeed = 2.0f;
    [SerializeField] float bounceForce = 2.0f;
    [SerializeField] float jumpForce = 7.0f;

    Rigidbody rb;
    CapsuleCollider col;

    float horizontalInput;
    float speed;
    float targetSpeedupPos = -10;
    
    bool hasWon;
    bool cannotJump = false;
    bool isSliding;

    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !cannotJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        SpeedUp();

        Win();

        Lose();

        Move();

        Slide();
    }

    public void SpeedUp()
    {
        if (transform.position.z > targetSpeedupPos)
        {
            speed *= 1.06f;
            targetSpeedupPos += 10;
        }
    }

    void Move()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        transform.position += Vector3.right * horizontalInput * horiSpeed * Time.deltaTime;
    }

    void Slide()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
            cannotJump = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            cannotJump = false;
        }
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
            if (collision.contacts[0].normal.z < -0.5f)
            {
                if (transform.position.y <= 1)
                {
                    rb.AddForce(collision.contacts[0].normal * bounceForce, ForceMode.Impulse);
                }
                else
                {
                    rb.AddForce(collision.contacts[0].normal * bounceForce / 3, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coffee")
        {
            Destroy(other.gameObject);
            FindObjectOfType<TimerText>().LowerTime(5);
        }

        if (other.gameObject.tag == "Bottle")
        {
            Destroy(other.gameObject);
            FindObjectOfType<TimerText>().IncreaseTime(2);
        }
    }

    private void Win()
    {
        if (hasWon)
        {
            Destroy(gameObject);
        }
    }

    private void Lose()
    {
        if (TimerText.IsTimeOut())
        {
            SceneManager.LoadScene("EndScene");
            TimerText.isTimeOut = false;
            Destroy(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();

        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 1)
        {
            Destroy(players[1]);
        }
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("SpawnPoint").transform.position;
    }

    public void ResetTargetSpeedUpPos()
    {
        targetSpeedupPos = -10;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}