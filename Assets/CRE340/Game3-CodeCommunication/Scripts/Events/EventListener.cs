using UnityEngine;
using System.Linq;
using TMPro;

public class EventListener : MonoBehaviour
{
    public TextMeshProUGUI logText; // Reference to the TextMeshProUGUI component
    public int lineCount = 10; // Number of lines to display in the log

    private void OnEnable()
    {
        HealthEventManager.OnObjectDamaged += HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed += HandleObjectDestroyed;
    }

    private void OnDisable()
    {
        HealthEventManager.OnObjectDamaged -= HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed -= HandleObjectDestroyed;
    }

    private void HandleObjectDamaged(string name, int remainingHealth)
    {
        string message = $"An object called {name} was damaged! Remaining Health: {remainingHealth}";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }

    private void HandleObjectDestroyed(string name, int remainingHealth)
    {
        string message = $"An object called {name} was destroyed!";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }

    private void UpdateLog(string message, int maxLines)
    {
        if (logText != null)
        {
            StopCoroutine("LerpFade");

            var lines = logText.text.Split('\n').ToList();

            lines.Add(message);

            if (lines.Count > maxLines)
            {
                lines.RemoveAt(0);
            }

            logText.text = string.Join("\n", lines);

            StartCoroutine("LerpFade");
        }
    }

    void LerpFade()
    {
        logText.overrideColorTags = true;

        if (logText.color != Color.clear) Color.Lerp (logText.color, Color.clear, 2 * Time.deltaTime);
    }
}
