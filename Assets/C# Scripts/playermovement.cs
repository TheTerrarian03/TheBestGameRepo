// co-written by ChatGPT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private float moveSpeed = 4f;           // Speed at which the player moves
    private float jumpForce = 4.5f;           // Force applied when the player jumps
    private float gravity = -2.0f;
    private int maxJumps = 1;               // Maximum number of jumps allowed
    private float groundThreshold = 0.6f;  // Max Distance to detect ground below player

    private CharacterController charController;
    private Vector3 movement;
    private int jumpsRemaining;
    private float vertSpeed;
    private bool isGrounded;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        jumpsRemaining = maxJumps;
        vertSpeed = gravity;
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
        // Apply gravity
        ApplyGravity();
        // Move the player
        MovePlayer();
    }

    private void ApplyGravity()
    {
        vertSpeed -= gravity;
    }

    private void MovePlayer()
    {
        // scale movement by player speed
        Vector3 desiredVelocity = movement * moveSpeed;
        desiredVelocity *= Time.deltaTime;
        // set player velocity
        charController.Move(desiredVelocity);
    }

    private void Jump()
    {
        // add a force to the player
        vertSpeed = jumpForce;
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
