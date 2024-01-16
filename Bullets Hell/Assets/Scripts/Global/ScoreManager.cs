using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string suffix = " pts";
    private int score = 0;

    private void Start()
    {
        UpdateScore();
    }

    public void AddScore(int pointToAdd)
    {
        score += pointToAdd;
        UpdateScore();
    }

    public void RemoveScore(int pointToRemove)
    {
        score -= pointToRemove;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score + suffix;
    }

}
