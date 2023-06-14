using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PancakeFlip : MonoBehaviour
{
    Animator animator;
    public bool click;

    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;

    private bool canFlip;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        click = false;
        canFlip = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFlip && Input.GetMouseButtonDown(0))
        {
            canFlip = false;
            click = true;
            StartCoroutine(UpdatePoints());
        }
        else
        {
            click = false;
        }

        animator.SetBool("Click", click);
    }

    IEnumerator UpdatePoints()
    {
        canFlip = false;
        yield return new WaitForSeconds(0.5f);
        playerInfoManager.adjustPoints(1);
        canFlip = true;
    }
}

//I need help. I can't figure out how to turn off inputs.