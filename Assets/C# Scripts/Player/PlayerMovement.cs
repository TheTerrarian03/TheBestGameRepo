using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ----- Variable Variables :D -----
    private CharacterController charController;
    private float vertSpeed;
    private int jumpsLeft;
    private Vector3 lastMoveSpeed;

    private const float SCALE = 0.4f;

    // ----- Constant Variables ------
    private const float SPEED               = 6.0f * SCALE;
    private const float JUMP_FORCE          = 13.0f * SCALE;
    private const float GRAVITY             = -45f * SCALE;
    private const float GROUNDED_VERT_FORCE = -1.0f;
    private int MAX_JUMPS                   = 2;

    // ----- Constants, For Positioning -----
    [SerializeField]
    private float MAX_Z_DEPTH = -1;
    [SerializeField]
    private float MIN_Z_DEPTH = 1f;

    // ----- Unity Methods -----
    private void Awake()
    {
        // get character controller reference
        charController = GetComponent<CharacterController>();
    }

    void Start()
    {
        // set variables to initial state
        vertSpeed = GRAVITY;
        jumpsLeft = MAX_JUMPS;
    }

    void Update()
    {
        // get user input
        float horizontalInput = Input.GetAxis("Horizontal") * SPEED;
        float verticalInput   = Input.GetAxis("Vertical")   * SPEED;

        // set movement vector and clamp to speed
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Vector3.ClampMagnitude(movement, SPEED);

        // apply jump
        Jump();

        // apply vertical speed, then scale by delta time
        movement.y = vertSpeed;
        movement *= Time.deltaTime;

        // convert from local to world space, and move
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
        lastMoveSpeed = movement;

        clampZDepth();
    }

    private void clampZDepth()
    {
        Vector3 pos = transform.position;
        if (pos.z < MAX_Z_DEPTH)
            pos.z = MAX_Z_DEPTH;
        if (pos.z > MIN_Z_DEPTH)
            pos.z = MIN_Z_DEPTH;
        transform.position = pos;
    }

    private void Jump()
    {
        if (charController.isGrounded)
        {
            // if grounded, reset jumps
            jumpsLeft = MAX_JUMPS;
            vertSpeed = GROUNDED_VERT_FORCE;
        }
        else
            // else, apply gravity scaled by delta time
            vertSpeed += GRAVITY * Time.deltaTime;

        // if user pressed the jump button and there are jumps left, apply "forces"
        if ((Input.GetButtonDown("Jump")) && (jumpsLeft > 0))
        {
            vertSpeed = JUMP_FORCE;
            jumpsLeft -= 1;
        }
    }

    public Vector3 getLastSpeed()
    {
        return lastMoveSpeed;
    }

    public Vector3 getLastSpeedScaled()
    {
        return getLastSpeed() / SPEED / Time.deltaTime;
    }

    public bool getIsJumping()
    {
        return vertSpeed > 0;
    }
}