using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointAdjustByAmount : MonoBehaviour
{
    [SerializeField]
    private int adjustAmount = 2;
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerManager.adjustPoints(adjustAmount);
        }
    }
}
