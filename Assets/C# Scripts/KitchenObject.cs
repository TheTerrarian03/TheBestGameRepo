using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    // ----- Enum for rotation axis selection -----
    private enum RotationAxis
    {
        X,
        Y,
        Z
    }

    // ----- UI Manager Reference ------
    [SerializeField]
    private UIManager uimanager;

    // ----- Tooltip Things -----
    [SerializeField]
    private string tooltipMessage;
    [SerializeField]
    private float tooltipLifetime = 1.5f;

    // ----- Rotation Things -----
    [SerializeField]
    private bool rotateOnClick = false;
    [SerializeField]
    private RotationAxis rotationAxis;
    [SerializeField]
    private Transform rotationPoint;
    [SerializeField]
    private float initialRotation;
    [SerializeField]
    private float targetRotation;

    // ----- Smooth Movement Things -----
    [SerializeField]
    private bool doSmoothRotation = false;
    [SerializeField]
    private float moveTime = 0.5f;

    private bool atInitialRotation = true;

    private void Start()
    {
        if (rotateOnClick)
            setRotation(initialRotation);
    }

    private void OnMouseEnter()
    {
        if (tooltipMessage != null)
            uimanager.setTooltipText(tooltipMessage, 1.5f);
    }

    private void OnMouseDown()
    {
        if ((rotateOnClick) && (rotationPoint != null))
        {
            if (atInitialRotation)
            {
                atInitialRotation = false;

                if (doSmoothRotation)
                    StartCoroutine(smoothlyRotate(targetRotation));
                else
                    setRotation(targetRotation);
            } else
            {
                atInitialRotation = true;

                if (doSmoothRotation)
                    StartCoroutine(smoothlyRotate(-targetRotation));
                else
                    setRotation(-targetRotation);
            }
            Debug.Log(atInitialRotation);
        }
    }

    private IEnumerator smoothlyRotate(float angle)
    {
        float frames = 60 * moveTime;

        for (int i = 0; i < frames; i++)
        {
            yield return new WaitForSeconds(1/60);
            setRotation(angle / frames);
        }
    } 

    private void setRotation(float angle)
    {
        // Calculate the rotation axis based on the selected option
        Vector3 rotationAxisVector;
        switch (rotationAxis)
        {
            case RotationAxis.X:
                rotationAxisVector = Vector3.right;
                break;
            case RotationAxis.Y:
                rotationAxisVector = Vector3.up;
                break;
            case RotationAxis.Z:
                rotationAxisVector = Vector3.forward;
                break;
            default:
                rotationAxisVector = Vector3.up;
                break;
        }

        // Rotate gameobject around rotation point
        transform.RotateAround(rotationPoint.position, rotationAxisVector, angle);
    }
}
