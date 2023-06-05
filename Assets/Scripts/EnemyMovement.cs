using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // ----- Variable Variables :D -----
    private CharacterController charController;
    private float vertSpeed;
    

    // ----- Constant Variables ------
    private const float SPEED = 4.0f;
    
    private const float GRAVITY = -45f;
    private const float GROUNDED_VERT_FORCE = -1.0f;
    

    // ----- Constants, For Positioning -----
    private const float MAX_Z_DEPTH = -1.5f;
    private const float MIN_Z_DEPTH = 1.125f;

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
    }

    void Update()
    {
        // get user input
        float horizontalInput = Input.GetAxis("Horizontal") * SPEED;
        float verticalInput = Input.GetAxis("Vertical") * SPEED;

        // set movement vector and clamp to speed
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Vector3.ClampMagnitude(movement, SPEED);
        

        // apply vertical speed, then scale by delta time
        movement.y = vertSpeed;
        movement *= Time.deltaTime;

        // convert from local to world space, and move
        movement = transform.TransformDirection(movement);
        charController.Move(movement);

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

}