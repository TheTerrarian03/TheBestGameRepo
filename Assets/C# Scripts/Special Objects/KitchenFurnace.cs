using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenFurnace : MonoBehaviour
{
    // ----- UI Manager Reference ------
    [SerializeField]
    private UIManager uimanager;

    // ----- Tooltip Things -----
    [SerializeField]
    private string tooltipMessage;
    [SerializeField]
    private float tooltipLifetime = 1.5f;

    // ----- Target Scene -----
    [SerializeField]
    private string targetScene;

    [SerializeField]
    private bool resetPointsOnSceneChange = false;
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;

    private void OnMouseEnter()
    {
        if ((tooltipMessage != null) && (uimanager != null))
            uimanager.setTooltipText(tooltipMessage, 1.5f);
    }

    private void OnMouseDown()
    {
        if (targetScene != null)
            SceneManager.LoadScene(targetScene);

        if (resetPointsOnSceneChange && (playerInfoManager != null))
            playerInfoManager.resetPoints();
    }
}
