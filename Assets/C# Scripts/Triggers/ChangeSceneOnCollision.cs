using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    [SerializeField]
    private string triggerTag = "Player";  // Tag of the object that triggers the scene change
    [SerializeField]
    private string sceneName = "NewScene";  // Name of the scene to load

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag(triggerTag))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}