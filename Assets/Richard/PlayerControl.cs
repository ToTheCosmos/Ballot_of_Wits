using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float slideForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when the space bar is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.AddForce(Vector3.down * slideForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Move the character horizontally
        //float moveInput = Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0f);
        //rb.velocity = movement;

        // Apply a slide force when the player presses the "S" key
        /*if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * slideForce, ForceMode.Impulse);
        }*/
    }
}
