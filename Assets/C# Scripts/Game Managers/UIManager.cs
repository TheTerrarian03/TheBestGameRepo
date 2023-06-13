using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // ----- Text Objects To Edit -----
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private TMP_Text pointsText;
    [SerializeField]
    private TMP_Text tooltipText;

    // ---- Customization options -----
    [SerializeField]
    private int pointGoal;
    [SerializeField]
    private int fullHealth;
    [SerializeField]
    private bool doColors = true;

    // ----- Player Manager -----
    [SerializeField]
    private PlayerInfoManagerScriptableObject playerInfoManager;

    // ----- Unity Methods -----
    private void Start()
    {
        // setup initial text
        setHealthText(playerInfoManager.getHealth());
        setPointsText(playerInfoManager.getPoints());
        setTooltipText("");
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
        {
            // text
            if (fullHealth > 0)
                healthText.text = "Health: " + amount.ToString() + "/" + fullHealth.ToString();
            else
                healthText.text = "Health: " + amount.ToString();

            // colors
            if (doColors)
                if (amount == fullHealth)
                    healthText.color = new Color32(25, 255, 25, 255);
                else if (amount < 0)
                    healthText.color = new Color32(255, 25, 25, 255);
                else
                    healthText.color = new Color32(255, 128, 25, 255);
        }

    }

    // ----- Points Methods -----
    public void setPointsText(int amount)
    {
        // set points text if the object exists
        if (pointsText != null)
        {
            // text
            if (pointGoal > 0)
                pointsText.text = "Points: " + amount.ToString() + "/" + pointGoal.ToString();
            else
                pointsText.text = "Points: " + amount.ToString();

            // colors
            if (doColors)
                if (amount >= pointGoal)
                    pointsText.color = new Color32(25, 255, 25, 255);
                else if (amount == 0)
                    pointsText.color = new Color32(255, 25, 25, 255);
                else
                    pointsText.color = new Color32(255, 128, 25, 255);
        }
    }

    // ----- Tooltip Methods -----
    public void setTooltipText(string tip, float lifetimeSeconds = -1)
    {
        if (tooltipText == null)
            return;

        tooltipText.text = tip;

        if (lifetimeSeconds > 0)
            StartCoroutine(clearTooltipAfterSeconds(lifetimeSeconds));
    }

    private IEnumerator clearTooltipAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        setTooltipText("");
    }

    // ----- Getter methods -----
    public int getFullHealth()
    {
        return fullHealth;
    }

    public int getPointGoal()
    {
        return pointGoal;
    }
}