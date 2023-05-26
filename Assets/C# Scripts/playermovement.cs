// co-written by ChatGPT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private float moveSpeed = 4f;           // Speed at which the player moves
    private float jumpForce = 3.5f;           // Force applied when the player jumps
    private int maxJumps = 1;               // Maximum number of jumps allowed
    private float groundThreshold = 0.6f;  // Max Distance to detect ground below player

    private Rigidbody playerRigidbody;
    private Vector3 movement;
    private int jumpsRemaining;
    private bool isGrounded;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        // ----- GET USER X Y INPUT -----
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // ----- MAKE NEW MOVEMENT VECTOR -----
        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // ----- APPLY JUMP IF NEEDED -----
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            Jump();
        }

        // ----- DETECT GROUND -----
        detectGround();
    }

    private void FixedUpdate()
    {
        // Move the player
        MovePlayer();
    }

    private void MovePlayer()
    {
        // scale movement by player speed
        Vector3 desiredVelocity = movement * moveSpeed;
        // set player velocity
        playerRigidbody.velocity = new Vector3(desiredVelocity.x, playerRigidbody.velocity.y, desiredVelocity.z);
    }

    private void Jump()
    {
        // add a force to the player
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // decrement the jumps remaining
        jumpsRemaining--;
    }

    private void detectGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundThreshold))
        {
            isGrounded = true;
            jumpsRemaining = maxJumps;
        }
        else
        {
            isGrounded = false;
        }
        //Debug.DrawRay(transform.position, Vector3.down * groundThreshold, Color.red);
    }
}
