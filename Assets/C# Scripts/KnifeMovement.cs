using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    private float throwForce = 10f;  // The force to throw the knife
    private  float lifeTime = 2.5f;  // The duration after which the knife will disappear

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * throwForce, ForceMode.Impulse);

        // Schedule the knife to disappear after the specified lifetime
        Destroy(gameObject, lifeTime);
    }
}