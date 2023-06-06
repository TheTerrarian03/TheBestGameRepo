using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lastMoveSpeed = playerMovement.getLastSpeed();
        animator.SetFloat("PlayerSpeed", lastMoveSpeed.x);
    }
}
