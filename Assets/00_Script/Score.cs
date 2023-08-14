using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    
    [SerializeField] private TextMeshProUGUI CurrentScoreValue;
    [SerializeField] private TextMeshProUGUI BestScoreValue;

    private int _score;

    private void Awake()
    {
        if(Instance == null) {Instance = this;}
    }

    private void Start()
    {
        CurrentScoreValue.text = "0";
        BestScoreValue.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    private void UpdateHighScore()
    {
        if(_score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", _score);
            BestScoreValue.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        CurrentScoreValue.text = _score.ToString();
        UpdateHighScore();
    }
}
