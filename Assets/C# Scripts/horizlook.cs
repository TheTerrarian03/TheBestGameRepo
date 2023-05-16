using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizlook : MonoBehaviour
{
    //mousesensitivity
    public float mousesens = 9.0f;
    //makes rigidbody visible to script
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //assigns component to rigidbody
        rb = GetComponent<Rigidbody>();
        //freezes rotation of rigidbody
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotates rigidbody yaw with mouseX
        transform.Rotate(0, Input.GetAxis("Mouse X") * mousesens, 0);
    }
}
