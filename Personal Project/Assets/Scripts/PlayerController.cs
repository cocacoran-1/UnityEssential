using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    bool isGrounded = true;
    public float jumpForce = 2.5f;
    public float gravityScale = 1f;
    public float speed = 50f;
    float zBound = -5f;
    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * verticalInput * speed);
        playerRb.AddForce(Vector3.right * horizontalInput * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            playerRb.velocity = Vector3.zero;
        }
    }
    void OnCOllisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with an enemy!");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}

