using UnityEngine;
using TMPro;

public class UI_EventListener : MonoBehaviour
{
    private UI_Display uiDisplay;

    private void Awake()
    {
        uiDisplay = GetComponent<UI_Display>();
    }

    private void OnEnable()
    {
        UIEventHandler.OnPlayerNameChanged += UpdatePlayerName;
        UIEventHandler.OnPlayerHealthChanged += UpdatePlayerHealth;
        UIEventHandler.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        UIEventHandler.OnPlayerNameChanged -= UpdatePlayerName;
        UIEventHandler.OnPlayerHealthChanged -= UpdatePlayerHealth;
        UIEventHandler.OnScoreChanged -= UpdateScore;
    }

    private void UpdatePlayerName(string playerName)
    {
        if(uiDisplay != null)
        {
            uiDisplay.UpdatePlayerName(playerName);
        }
    }

    private void UpdatePlayerHealth(int playerHealth)
    {
        if(uiDisplay != null)
        {
            uiDisplay.UpdatePlayerHealth(playerHealth);
        }
    }

    private void UpdateScore(int score)
    {
        if(uiDisplay != null)
        {
            uiDisplay.UpdateScore(score);
        }
    }
}
