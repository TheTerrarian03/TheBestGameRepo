using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdjOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string triggerTag = "Player";
    [SerializeField]
    private int adjustAmount = 2;
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            playerManager.adjustPoints(adjustAmount);
        }
    }
}
