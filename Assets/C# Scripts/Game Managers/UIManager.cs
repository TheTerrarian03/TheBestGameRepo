using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // ----- Text Objects To Edit -----
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private TMP_Text pointsText;

    // ----- Player Manager -----
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;

    // ----- Unity Methods -----
    private void Start()
    {
        // setup initial text
        setHealthText(playerInfoManager.getHealth());
        setPointsText(playerInfoManager.getPoints());
    }

    private void OnEnable()
    {
        // add listeners to events
        playerInfoManager.healthChangeEvent.AddListener(setHealthText);
        playerInfoManager.pointChangeEvent.AddListener(setPointsText);
    }

    private void OnDisable()
    {
        // remove listeners from events
        playerInfoManager.healthChangeEvent.RemoveListener(setHealthText);
        playerInfoManager.pointChangeEvent.RemoveListener(setPointsText);
    }

    // ----- Health Methods -----
    public void setHealthText(int amount)
    {
        // set health text if the object exists
        if (healthText != null)
            healthText.text = "Health: " + amount.ToString();
    }

    // ----- Points Methods -----
    public void setPointsText(int amount)
    {
        // set points text if the object exists
        if (pointsText != null)
            pointsText.text = "Points: " + amount.ToString();
    }
}