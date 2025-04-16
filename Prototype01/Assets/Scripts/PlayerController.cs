using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float horesPower = 5f;
    [SerializeField] float turnSpeed = 25f;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedoMeterText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] float speed;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;    

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horesPower * verticalInput);
            transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedoMeterText.SetText("Speed: " + speed + "mph");
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround >= 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
