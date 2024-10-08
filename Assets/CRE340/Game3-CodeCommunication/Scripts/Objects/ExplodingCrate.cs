using UnityEngine;

public class ExplodingCrate : MonoBehaviour, IDamagable
{
    public int health = 10;
    public GameObject explosionEffectPrefab;
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

        HealthEventManager.OnObjectDamaged?.Invoke(health);

        ShowHitEffect();
        if (health <= 0)
        {
            Explode();

            HealthEventManager.OnObjectDestroyed?.Invoke(health);
            
            Destroy(gameObject);
        }
    }

    public void ShowHitEffect()
    {
        mat.color = Color.red;
        Invoke("ResetMaterial", 0.1f);
    }

    private void ResetMaterial()
    {
        mat.color = originalColor;
    }

    private void Explode()
    {
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab,transform.position, Quaternion.identity);
        }
    }
}
