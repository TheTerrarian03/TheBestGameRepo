using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    [SerializeField]
    private string triggerTag = "Player";  // Tag of the object that triggers the scene change
    [SerializeField]
    private string sceneName = "NewScene";  // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAA");
        if (other.CompareTag(triggerTag))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}