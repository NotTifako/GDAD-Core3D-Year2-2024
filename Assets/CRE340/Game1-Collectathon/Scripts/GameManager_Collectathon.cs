using System;
using TMPro;
using UnityEngine;

public class GameManager_Collectathon : MonoBehaviour
{
    public static GameManager_Collectathon instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject winText;
    public GameObject gameOverText;

    PlayerController playerController;
    private int score = 0;
    public int totalCollectibles = 100;
    private float timer = 120f; // 2 minutes

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        totalCollectibles = FindObjectsOfType<Collectible>().Length;
        playerController = FindObjectOfType<PlayerController>();

        UpdateScoreText();
        winText.SetActive(false);
        gameOverText.SetActive(false);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        UpdateTimerText();

        if (totalCollectibles == 0)
        {
            totalCollectibles = FindObjectsOfType<Collectible>().Length;
        }

        if (timer <= 0)
        {
            GameOver();
        }

        if (score >= totalCollectibles && totalCollectibles > 0)
        {
            Win();
        }
    }

    public void IncreaseScore()
    {
        score ++;
        UpdateScoreText();
    }

    public void IncreaseTimer()
    {
        timer += 25;
        UpdateTimerText();
    }

    public void IncreaseSpeed()
    {
        playerController.speed = 5;
        Invoke("ReturnSpeedToNormal", 5f);
    }

    void ReturnSpeedToNormal()
    {
        playerController.speed = 3;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
    }

    public void DecreaseTotalCollectibles()
    {
        totalCollectibles = FindObjectsOfType<Collectible>().Length;
    }

    void Win()
    {
        winText.SetActive(true);
        Time.timeScale = 0f;
    }

    void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0f;
    }
}
