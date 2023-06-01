using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerInfoManager", menuName = "Scriptable Objects/PlayerInfoManager")]
public class PlayerInfoManagerScriptableObject : ScriptableObject
{
    // ----- Current variables -----
    [SerializeField]
    private int health;
    [SerializeField]
    private int points;

    // ------ consts -----
    [SerializeField]
    private int maxHealth = 100;

    // ----- Events -----
    [System.NonSerialized]
    public UnityEvent<int> healthChangeEvent;
    [System.NonSerialized]
    public UnityEvent<int> pointChangeEvent;

    // ----- Unity Calls -----
    private void OnEnable()
    {
        health = maxHealth;
        points = 0;

        if (healthChangeEvent == null)
            healthChangeEvent = new UnityEvent<int>();

        if (pointChangeEvent == null)
            pointChangeEvent = new UnityEvent<int>();
    }

    // ----- Health Methods -----
    public int getHealth()
    {
        return health;
    }

    public void adjustHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(maxHealth, health);
        healthChangeEvent.Invoke(health);
    }

    // ----- Point Methods -----
    public void adjustPoints(int amount)
    {
        points += amount;
        points = Mathf.Max(0, points);
        pointChangeEvent.Invoke(points);
    }

    public int getPoints()
    {
        return points;
    }
}
