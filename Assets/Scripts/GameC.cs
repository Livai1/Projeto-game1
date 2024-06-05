using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameC : MonoBehaviour
{
    public Text healthTxt;

    public Text scoreTxt;

    public int totalScore;
    public int Score;

    public GameObject pauseObj;

    private bool isPaused;

    public GameObject gameOverObj;

    public static GameC Instance;

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
        Score += value;
        scoreTxt.text = Score.ToString();

         PlayerPrefs.SetInt("score", Score + totalScore);
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
