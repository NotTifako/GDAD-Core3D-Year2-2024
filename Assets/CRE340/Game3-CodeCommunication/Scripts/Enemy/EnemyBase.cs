using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamagable
{
    protected Color originalColor;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }

    public abstract void TakeDamage(int damage);
    protected abstract void Die();
    
    public abstract void Move();

    public void ShowHitEffect()
    {
        if(mat == null)
        {
            mat = GetComponent<Renderer>().material;
            originalColor = mat.color;
        }
        mat.color = Color.red;
        Invoke("ResetMaterial", 0.1f);
    }

    protected void ResetMaterial()
    {
        mat.color = originalColor;
    }
}