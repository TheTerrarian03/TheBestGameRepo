using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointMeetDependentSceneChange : MonoBehaviour
{
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private string newSceneName;
    [SerializeField]
    private string triggerTag = "Player";

    private Renderer cubeRenderer;
    private Color RED = new Color(1f, 0f, 0f, 1f);
    private Color GREEN = new Color(0f, 1f, 0f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component from the new cube
        cubeRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // look for point amount
        if (playerInfoManager.getPoints() >= uiManager.getPointGoal())
            setColor(GREEN);
        else
            setColor(RED);
    }

    private void setColor(Color newColor)
    {
        // Call SetColor using the shader property name "_Color" and setting the color to the custom color you created
        cubeRenderer.material.SetColor("_Color", newColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            if (playerInfoManager.getPoints() >= uiManager.getPointGoal())
                SceneManager.LoadScene(newSceneName);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(triggerTag))
        {
            if (playerInfoManager.getPoints() >= uiManager.getPointGoal())
                SceneManager.LoadScene(newSceneName);
        }
    }
}
