using System.Collections;
using UnityEngine;


public class EventReceiver : MonoBehaviour
{
    //private Material originalMaterial;
    //private Material onFireMaterial;

    private void OnEnable()
    {
        EventSender.OnFire += HandleFireEvent;
    }

    private void OnDisable()
    {
        EventSender.OnFire -= HandleFireEvent;
    }

    private void HandleFireEvent(Material original, Material onFire)
    {
        StartCoroutine(IncreaseBrightness(original, onFire));
    }

    private IEnumerator IncreaseBrightness(Material original, Material onFire)
    {
        GetComponent<Renderer>().material = onFire;
        yield return new WaitForSeconds(0.2f);
        GetComponent<Renderer>().material = original;
    }
}
