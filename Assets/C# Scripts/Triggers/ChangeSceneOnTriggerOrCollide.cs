using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTriggerOrCollide : MonoBehaviour
{
    [SerializeField]
    private string triggerTag = "Player";  // Tag of the object that triggers the scene change
    [SerializeField]
    private string sceneName = "NewScene";  // Name of the scene to load

    [SerializeField]
    private bool resetPointsOnSceneChange = false;
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAA");
        if (other.CompareTag(triggerTag))
        {
            SceneManager.LoadScene(sceneName);

            if (resetPointsOnSceneChange && (playerInfoManager != null))
                playerInfoManager.resetPoints();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag(triggerTag))
        {
            SceneManager.LoadScene(sceneName);

            if (resetPointsOnSceneChange && (playerInfoManager != null))
                playerInfoManager.resetPoints();
        }
    }
}