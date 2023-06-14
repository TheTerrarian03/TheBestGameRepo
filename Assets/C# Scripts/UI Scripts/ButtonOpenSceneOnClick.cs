using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOpenSceneOnClick : MonoBehaviour
{
    [SerializeField]
    public string targetScene;

    [SerializeField]
    private bool resetPointsOnSceneChange = false;
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;

    public void WhenTheButtonIsClicked()
    {
        SceneManager.LoadScene(targetScene);

        if (resetPointsOnSceneChange && (playerInfoManager != null))
            playerInfoManager.resetPoints();
    }
}
