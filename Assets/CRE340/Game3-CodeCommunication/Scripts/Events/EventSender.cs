using UnityEngine;

public class EventSender : MonoBehaviour
{
    public delegate void FireEventHandler(Material originalMaterial, Material onFireMaterial);
    public static event FireEventHandler OnFire;

    public Material originalMaterial;
    public Material onFireMaterial;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnFire != null)
            {
                OnFire(originalMaterial, onFireMaterial);
            }
        }
    }
}
