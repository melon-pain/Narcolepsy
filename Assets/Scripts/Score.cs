using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score: <color=#00FF00><b>{score}</b></color>";
    }
}
