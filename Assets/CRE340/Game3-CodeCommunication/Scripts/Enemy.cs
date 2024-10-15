using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyData enemyData;

    private Material mat;
    private Color originalColor;

    private void Start()
    {
        gameObject.name = enemyData.enemyName;
        mat = GetComponent<Renderer>().material;
        mat.color = enemyData.enemyColor;
        originalColor = mat.color;
    }

    public void TakeDamage(int damage)
    {
        enemyData.health -= damage;

        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, enemyData.health);

        ShowHitEffect();
        if (enemyData.health <= 0)
        {
            Die();
            
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, enemyData.health);
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

    private void Die()
    {
        Destroy(gameObject);
    }
}
