using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointAdd : MonoBehaviour
{
    public Text pointText;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "Points: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
