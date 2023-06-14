using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject knifePrefab;  // Reference to the knife prefab

    private bool hasThrown = false;

    void Update()
    {
        if (!hasThrown && Input.GetAxis("Fire1") > 0.5f)
        {
            throwKnife();
        }

        if (Input.GetAxis("Fire1") <= 0.5f)
        {
            hasThrown = false;
        }
    }

    private void throwKnife()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 1.5f;  // Distance from the camera

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, worldPosition - transform.position);

        Instantiate(knifePrefab, transform.position, rotation);

        hasThrown = true;
    }
}