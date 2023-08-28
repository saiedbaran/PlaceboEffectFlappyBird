using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

struct GamePlayData
{
    public float Duration;
    public float Score;
    public float Attempt;
}

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/GameStats")]
public class GameStat : ScriptableObject
{
    public float gameDuration = 0;
    public float numberOfAttempt = 0;
    public float highScore = 0;
    public string gamePlayData = "";
    
    
    public void Reset()
    {
        gameDuration = 0;
        numberOfAttempt = 0;
        highScore = 0;
    }

    public void ConvertToJson()
    {
        GamePlayData data = new GamePlayData
        {
            Duration = gameDuration,
            Score = highScore,
            Attempt = numberOfAttempt
        };
        
        gamePlayData = JsonUtility.ToJson(data, true);
    }
}


