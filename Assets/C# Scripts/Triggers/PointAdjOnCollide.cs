using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdjOnCollide : MonoBehaviour
{
    [SerializeField]
    private string triggerTag = "PlayerWeapon";
    [SerializeField]
    private int adjustAmount = 2;
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(triggerTag))
        {
            playerManager.adjustPoints(adjustAmount);
        }
    }
}
