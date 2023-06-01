using UnityEngine;

public class PlayerHealthAdjustByAmount : MonoBehaviour
{
    [SerializeField]
    private int adjustAmount = 10;
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerManager.adjustHealth(adjustAmount);
        }
    }
}
