using UnityEngine;
using System.Linq;

using TMPro;
using UnityEngine.Rendering;

public class EventListener : MonoBehaviour
{
    
    public TextMeshProUGUI logText; // Reference to the TextMeshProUGUI component
    public int lineCount = 10; // Number of lines to display in the log
    
    private void OnEnable()
    {
        // Subscribe to events
        HealthEventManager.OnObjectDamaged += HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed += HandleObjectDestroyed;

        InventoryManager.OnItemAdded += HandleItemAdded;
        InventoryManager.OnItemRemoved += HandleItemRemoved;
    }

    private void OnDisable()
    {
        // Unsubscribe from events to avoid memory leaks
        HealthEventManager.OnObjectDamaged -= HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed -= HandleObjectDestroyed;

        InventoryManager.OnItemAdded -= HandleItemAdded;
        InventoryManager.OnItemRemoved -= HandleItemRemoved;
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

    private void HandleItemAdded(InventoryItem item)
    {
        string message = $"{item.name} was added to the inventory.";
        UpdateLog(message, lineCount);
    }

    private void HandleItemRemoved(InventoryItem item)
    {
        string message = $"{item.name} was removed from the inventory.";
        UpdateLog(message, lineCount);
    }

    //use this for adding to the log text - this will add the message to the log text endlessly
    private void UpdateLog(string message)
    {
        if (logText != null)
        {
            logText.text += message + "\n"; // Append the message to the log text - split by new line
        }
    }
    
    //use this for adding to the log text - this will add the message to the log text with a limit of lines
    private void UpdateLog(string message, int maxLines)
    {
        if (logText != null)
        {
            // Split the current log text into lines
            var lines = logText.text.Split('\n').ToList();

            // Add the new message
            lines.Add(message);

            // Check if the number of lines exceeds the limit
            if (lines.Count >= maxLines)
            {
                // Remove the oldest line
                lines.RemoveAt(0);
            }

            // Join the lines back into a single string
            logText.text = string.Join("\n", lines);
        }
    }
}