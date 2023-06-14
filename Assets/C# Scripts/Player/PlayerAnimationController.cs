using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // PlayerMovement and PlayerAttack need to be passed in manually
    }

    void LateUpdate()
    {
        // ----- XZ Movement -----
        Vector3 lastMoveSpeed = playerMovement.getLastSpeedScaled();
        float moveSpeed;

        if (Mathf.Abs(lastMoveSpeed.z) > Mathf.Abs(lastMoveSpeed.x))
            moveSpeed = lastMoveSpeed.z;
        else
            moveSpeed = lastMoveSpeed.x;

        spriteRenderer.flipX = moveSpeed < 0 ? true : false;
        animator.SetFloat("PlayerSpeed", Mathf.Abs(moveSpeed));

        // ----- Jumping -----
        animator.SetBool("IsJumping", playerMovement.getIsJumping());
    }
}
