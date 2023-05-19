using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 starPos;
    [SerializeField]
    private Vector3 endPos;
    [SerializeField]
    private float moveTime;

    private float timeElapsed;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = starPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
            Debug.Log("AAAAAAA");
        }

        if (isMoving)
        {
            if (timeElapsed < moveTime)
            {
                Vector3 lerpedPosition = Vector3.Lerp(starPos, endPos, timeElapsed / moveTime);
                transform.position = lerpedPosition;
                timeElapsed += Time.deltaTime;
            }
        }
    }
}
