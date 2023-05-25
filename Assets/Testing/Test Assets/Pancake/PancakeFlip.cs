using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeFlip : MonoBehaviour
{
    Animator animator;
    public bool click;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        click = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click = true;
        }
        else
        {
            click = false;
        }

        if (click == false)
        {
            animator.SetBool("Click", false);
        }

        if (click == true)
        {
            animator.SetBool("Click", true);
        }
    }
}