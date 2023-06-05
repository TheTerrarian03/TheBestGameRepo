using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int enemySpeed;
    public int XMoveDirection;
    Rigidbody2D rigid2D;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        rigid2D.velocity = new Vector2(XMoveDirection, 0) * enemySpeed;
         gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * 
        enemySpeed;

        if (hit.distance < 0.7f && hit.collider != null)
        {
            // Flip();
            if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }

        
        void Flip()
        {
            if (XMoveDirection > 0)
            {
                XMoveDirection = -1;
            }    
            else
            {
                XMoveDirection = 1;
            }
        }
        
    }
}
 
