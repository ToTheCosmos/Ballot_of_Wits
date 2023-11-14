using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float jumpForce = 2f;
    public float slideForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float hitVelocity = 10f;

    private Rigidbody rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;

    public Animator anim;

    public Material Material1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim.Play("Running");
    }

    private void Update()
    {
        // Reset current scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when the space bar is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.Play("Jump");
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.AddForce(Vector3.down * slideForce, ForceMode.Impulse);
            anim.Play("Running");
        }
    }

    private void FixedUpdate()
    {
        // Apply downward force when player hits "S"
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * slideForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * hitVelocity, ForceMode.Impulse);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Poster")
        {
            Debug.Log("Within Range");
            if (Input.GetKey(KeyCode.W))
            {
                anim.Play("PosterHit");
                Debug.Log("Put up poster");
                other.GetComponentInChildren<MeshRenderer>().material = Material1;
            }
        }
    }
}
