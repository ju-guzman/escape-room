using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private SO_GameManager gameManager;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameUI;

    [SerializeField] private TextMeshProUGUI time;

    private void OnEnable()
    {
        gameManager.OnGameOver += ShowGameOver;
    }

    private void ShowGameOver()
    {
        ShowGameOverUI(gameManager.Time);
    }

    public void ShowGameOverUI(int time)
    {
        gameOverUI.SetActive(true);
        gameUI.SetActive(false);
        this.time.text = time + "";
    }

    public void Restart()
    {
        gameManager.StartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
