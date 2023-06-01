using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //public Text scoreText;

    public TMP_Text scoreText;

    [SerializeField] ScoreManager scoreManager;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Points: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
