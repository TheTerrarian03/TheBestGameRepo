using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //declares the character controller
    private CharacterController charController;
    //declares a speed variable
    public float speed = 6.0f;
    //declares a jump force
    public float jumpForce = 15.0f;
    //vertical speed, a second gravity variable
    private float vertSpeed;
    //declares the gravity
    private float gravity = -50.0f;
    //gets a variable of the current speed of the character
    public float currentforce;
    // Start is called before the first frame update
    void Start()
    {
        //sets the vert speed equal to gravity
        vertSpeed = gravity;
        //makes the character controller on the character as the character controller declared earlier
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //makes the a, d buttons input the left and right movement
        float horizontalInput = Input.GetAxis("Horizontal") * speed;
        //makes the w, s buttons input the forward and backward movement
        float verticalInput = Input.GetAxis("Vertical") * speed;
        //the vector movement is along x and z axis, equal to the button inputs from before
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        //clamps the force of it
        movement = Vector3.ClampMagnitude(movement, speed);
        //if the character controller is grounded, then jump is available
        if (charController.isGrounded)
        {
            //if jump is pressed, jumpforce is the vertical speed, not gravity
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpForce;
            }
        }
        else
        {
            //vertspeed is gravity after a few seconds
            vertSpeed += gravity * Time.deltaTime;
        }
        //movement up is vert speed
        movement.y = vertSpeed;
        //movement is clamped by time.deltatime
        movement *= Time.deltaTime;
        //movement transforms the character controller in the direction that is pressed
        movement = transform.TransformDirection(movement);
        //moves the character controller
        charController.Move(movement);
        currentforce = horizontalInput + verticalInput;
        if (Input.GetAxis("Fire3") == 1)
        {
            speed = 8f;
        }
        else
        {
            speed = 6f;
        }
    }
}
