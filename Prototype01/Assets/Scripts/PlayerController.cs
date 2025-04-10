using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float turnSpeed = 25f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // moves the car forward based on player input
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime * forwardInput);
        // rotates the car based on player input
        transform.Rotate(Vector3.up * turnSpeed * Time.fixedDeltaTime * horizontalInput);
    }
}
