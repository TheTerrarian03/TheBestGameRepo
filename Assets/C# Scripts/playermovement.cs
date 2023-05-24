using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    public float grounddistance;
    public float jumpForce;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(grounddistance, 0.54f, 1.39f);
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if(Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if(hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + grounddistance;
                transform.position = movePos;
            }
        }
        float jump = Input.GetAxis("Jump");
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(x, 0, y);
        rb.velocity = moveDirection * speed;
        if(x != 0 && x > 0)
        {
            sr.flipX = true;
        }
        else if(x != 0 && x > 0)
        {
            sr.flipX = true;
        }
    }
}
