using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertlook : MonoBehaviour
{
    //this goes on camera, horiz goes on player
    //mouse sensitiyivity
    public float mousesensy = 9.0f;
    //constraint for the vertical look angle
    private float constrainVert = 45.0f;
    //float of the current rotation
    private float vertrot = 0.0f;
    void Start()
    {
        //MainCamera = transform.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        //vertrotation minus mouse y axis times the mouse senseitivity
        vertrot -= Input.GetAxis("Mouse Y") * mousesensy;
        //clamps it so it cant go over the constraint
        vertrot = Mathf.Clamp(vertrot, -constrainVert, constrainVert);
        //horizontal rotation is a euler angle
        float horizontalrotation = transform.localEulerAngles.y;
        //vector3 for the rotation of the camera
        transform.localEulerAngles = new Vector3(vertrot, horizontalrotation, 0);
    }

}
