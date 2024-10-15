using UnityEngine;

public class Crate : MonoBehaviour, IDamagable
{
    public int health = 10;
    private Material mat;
    private Color originalColor;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, health);
        
        ShowHitEffect();
        if(health <= 0)
        {
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, health);
            Destroy(gameObject);
        }
    }

    public void ShowHitEffect()
    {
        mat.color = Color.green;
        Invoke("ResetMaterial", 0.1f);
    }

    private void ResetMaterial()
    {
        mat.color = originalColor;
    }
}
