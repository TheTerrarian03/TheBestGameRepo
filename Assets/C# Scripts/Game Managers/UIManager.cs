using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private TMP_Text pointsText;
    //[SerializeField]
    //private TMP_Text healthText;

    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;

    private void Start()
    {
        setHealthText(playerInfoManager.getHealth());
        setPointsText(playerInfoManager.getPoints());
    }

    private void OnEnable()
    {
        playerInfoManager.healthChangeEvent.AddListener(setHealthText);
        playerInfoManager.pointChangeEvent.AddListener(setPointsText);
    }

    private void OnDisable()
    {
        playerInfoManager.healthChangeEvent.RemoveListener(setHealthText);
        playerInfoManager.pointChangeEvent.RemoveListener(setPointsText);
    }

    public void setHealthText(int amount)
    {
        if (healthText != null)
            healthText.text = "Health: " + amount.ToString();
    }

    public void setPointsText(int amount)
    {
        if (pointsText != null)
            pointsText.text = "Points: " + amount.ToString();
    }
}
