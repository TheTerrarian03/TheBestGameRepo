using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIMovement : MonoBehaviour
{// References the enemy's Rigidbody2D component
    private Rigidbody2D enemyRigidbody;

    // Sets the enemy's movement speed
    [SerializeField]
    private int movementSpeed;

    // Checks if the enemy is moving (to be used with animations)
    private bool isMoving;

    // The direction in which the enemy will move
    private Vector2 directionToMove;

    // The random decision (0, 1 or 2) that represents which movement function the enemy will perform
    private int decisionValue;

    // The time remaining before the enemy chooses which movement function to perform again
    private float timeTilNextDecision;

    // The random float that will be used to determine for how long the enemy remains idle
    private float idleTime;

    // The random float that will be used to determine for how long the enemy moves left or right
    private float moveTime;

    // Use this for initialization
    void Start()
    {

        // Accesses the enemy's Rigidbody2D component
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        MakeMovementDecision();
    }

    /// <summary>
    /// Generates the decision for which type of movement the enemy will perform
    /// </summary>
    private void MakeMovementDecision()
    {
        // Chooses a value upon which the movement decision will be based
        decisionValue = Random.Range(0, 3);

        switch (decisionValue)
        {
            // Keeps the enemy standing still
            case 0:
                Idle();
                break;

            // Moves the enemy to the right
            case 1:
                MoveRight();
                break;

            // Moves the enemy to the left
            case 2:
                MoveLeft();
                break;
        }
    }

    /// <summary>
    /// Causes the enemy to stand still with idle animations 
    /// </summary>
    private void Idle()
    {
        // Sets the idle stance duration
        idleTime = Random.Range(5.0f, 10.0f);

        // Calculates the time until the enemy may decide to change its movement
        timeTilNextDecision = idleTime - Time.deltaTime;

        // Sets the movement bool to false to play the idle animations
        isMoving = false;

        // Stops the enemy's movement
        enemyRigidbody.velocity = Vector2.zero;

        // Checks if the enemy should make a decision on its next movement
        if (timeTilNextDecision < 0)
        {
            MakeMovementDecision();
        }

    }

    private void MoveRight()
    {
        moveTime = Random.Range(2.0f, 5.01f);
        timeTilNextDecision = moveTime - Time.deltaTime;
        isMoving = true;
        directionToMove = Vector2.right;
        transform.Translate(directionToMove * (movementSpeed * Time.deltaTime));

        if (timeTilNextDecision < 0)
        {
            MakeMovementDecision();
        }

    }

    private void MoveLeft()
    {
        moveTime = Random.Range(3.52f, -5.48f);
        timeTilNextDecision = moveTime - Time.deltaTime;
        isMoving = true;
        directionToMove = Vector2.left;
        transform.Translate(directionToMove * (movementSpeed * Time.deltaTime));

        if (timeTilNextDecision < 0)
        {
            MakeMovementDecision();
        }

    }
}
