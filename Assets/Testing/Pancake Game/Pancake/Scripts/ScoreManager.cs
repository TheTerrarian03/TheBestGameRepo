using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : ScriptableObject
{
    // ----- Current variables -----
    [SerializeField] 
    private int points;

    // ----- Events -----
    public UnityEvent<int> pointChangeEvent;

    private void OnEnable()
    {
        points = 0;

        if (pointChangeEvent == null)
            pointChangeEvent = new UnityEvent<int>();
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