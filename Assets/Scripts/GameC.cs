using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameC : MonoBehaviour
{
    public Text healthTxt;
    public Text scoreText;

    public int score;
    public int totalScore;

    public static GameC Instance;

    public GameObject pauseObj;
    public GameObject gameOverObj;

    private bool isPaused;

    void Awake()
    {
        Instance = this;    
    }

    void Start()
    {
        totalScore = PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        PauseGame();
    }

    public void UpdateLives(int value)
    {   
        healthTxt.text = "x" + value.ToString();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("score", score + totalScore);
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);

        }

        if(isPaused)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
    }


    public void GameOver()
    {
        gameOverObj.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
