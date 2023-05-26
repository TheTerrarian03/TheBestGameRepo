using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboardsprites : MonoBehaviour
{
    public Transform target;  // The object the sprite will look at
    public bool rotateOnlyY = false;  // Whether to only rotate the y-axis towards the target

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition;
            if (rotateOnlyY)
            {
                targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            }
            else
            {
                targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            }
            transform.LookAt(targetPosition);

        }
    }
}