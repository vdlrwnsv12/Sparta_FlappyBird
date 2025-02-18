using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public bool isGameOver = false;
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;

    private void Update()
    {
        if (isGameOver == true && Input.anyKeyDown)
        {
            RestartGame();
        }
    }
    private void Awake()
    {
        gameManager = this;
    }

    public void GameOver()
    {
        isGameOver = true;

        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;

        Debug.Log("Score: " + currentScore);
    }

}