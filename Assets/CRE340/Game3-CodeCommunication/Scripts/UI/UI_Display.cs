using UnityEngine;
using TMPro;

public class UI_Display : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI scoreText;

    public void UpdatePlayerName(string playerName)
    {
        if(playerNameText != null)
        {
            playerNameText.text = "Player: " + playerName;
        }
    }

    public void UpdatePlayerHealth(int playerHealth)
    {
        if(playerHealthText != null)
        {
            playerHealthText.text = "Health: " + playerHealth.ToString();
        }
    }

    public void UpdateScore(int score)
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
