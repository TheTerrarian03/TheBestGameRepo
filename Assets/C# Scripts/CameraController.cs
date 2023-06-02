using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ----- Cam view settings -----
    [SerializeField]
    private int newFOV = 60;

    // ----- Bools -----
    [SerializeField]
    private bool xAxisMove = false;
    [SerializeField]
    private bool yAxisMove = false;
    [SerializeField]
    private bool zAxisMove = false;

    // ----- Floats for offsets -----
    [SerializeField]
    private float xAxisOffset = 0.0f;
    [SerializeField]
    private float yAxisOffset = 0.0f;
    [SerializeField]
    private float zAxisOffset = 0.0f;

    // ----- Gameobject target to follow -----
    // -----     (such as a player)      -----
    [SerializeField]
    private GameObject followTarget;

    // -----    Camera to control    -----
    // ----- (gets camera of parent) -----
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.fieldOfView = newFOV;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Only if there is a target to follow
        if (followTarget != null)
        {
            // Get current position
            Vector3 pos = transform.position;

            // x-axis
            if (xAxisMove)
                pos.x = followTarget.transform.position.x + xAxisOffset;

            // y-axis
            if (yAxisMove)
                pos.y = followTarget.transform.position.y + yAxisOffset;

            // z-axis
            if (zAxisMove)
                pos.z = followTarget.transform.position.z + zAxisOffset;

            // set new position
            transform.position = pos;
        }
    }
}
