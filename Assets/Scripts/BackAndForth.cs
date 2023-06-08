using UnityEngine;


public class BackAndForth : MonoBehaviour
{
    public float delta = 4.7f;  // Amount to move left and right from the start point
    public float speed = 1.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}

