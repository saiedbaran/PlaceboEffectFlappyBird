using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameStat gameStat;
    [SerializeField] private float maxGameDuration = 10;
    

    private void Awake()
    {
        if(Instance == null) {Instance = this;}
        
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0.0f;

        gameStat.highScore = PlayerPrefs.GetInt("BestScore", 0);
        gameStat.numberOfAttempt++;
        gameStat.gameDuration += Time.timeSinceLevelLoad;

        if (gameStat.gameDuration > maxGameDuration)
        {
            gameStat.ConvertToJson();
            gameStat.Reset();
            SceneManager.LoadScene("10_SurveyScene");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
