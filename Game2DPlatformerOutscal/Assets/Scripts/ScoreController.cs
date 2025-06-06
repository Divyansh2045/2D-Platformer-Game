using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
       
    }
    private void Start()
    {
        RefreshUI();
    }

    public void IncrementScore(int increment)
    {
        score = score + increment;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score;
    }
}
