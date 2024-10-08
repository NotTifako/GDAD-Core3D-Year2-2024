using UnityEngine;

public class EventListener : MonoBehaviour
{
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

    private void HandleObjectDamaged(int remainingHealth)
    {
        Debug.Log($"An object was damaged! Remaining Health: {remainingHealth}");
    }

    private void HandleObjectDestroyed(int remainingHealth)
    {
        Debug.Log("An object was destroyed!");
    }
}
