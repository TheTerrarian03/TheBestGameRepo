using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private CharacterController charController;
    private float speed = 6.0f;
    private float jumpForce = 15.0f;
    private float vertSpeed;
    private float gravity = -50f;

    private int MAX_JUMPS = 4;
    private int jumpsLeft;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        vertSpeed = gravity;
        jumpsLeft = MAX_JUMPS;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed;
        //float verticalInput = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        movement = Vector3.ClampMagnitude(movement, speed);

        Jump();

        movement.y = vertSpeed;
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        charController.Move(movement);

        Debug.Log(jumpsLeft);
    }

    void Jump()
    {
        if (charController.isGrounded)
        {
            jumpsLeft = MAX_JUMPS;
        }
        else
        {
            vertSpeed += gravity * Time.deltaTime;
        }

        if ((Input.GetButtonDown("Jump")) && (jumpsLeft > 0))
        {
            vertSpeed = jumpForce;
            jumpsLeft -= 1;
        }
    }
}