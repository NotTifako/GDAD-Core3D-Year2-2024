using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Enemy : EnemyBase
{
    public EnemyData enemyData; // Reference to the EnemyData ScriptableObject

    [SerializeField] private int damage = 10;
    [SerializeField] private int health = 10;

    public float speed = 2f;
    public float chaseRange = 5f;

    private IEnemyState currentState;

    public Transform target;
    public GameObject dieEffectPrefab; // Reference to the die effect prefab

    private Material material;



    private void Awake()
    {
        // Apply the data from the ScriptableObject to the enemy
        gameObject.name = enemyData.enemyName;
        health = enemyData.health;
        damage = enemyData.damage;
        speed = enemyData.speed;
        chaseRange = enemyData.chaseRange;

        GetComponent<Renderer>().material.color = enemyData.enemyColor;
    }

    private void Start() 
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;

        SetState(new EnemyState_Idle());
        Invoke("LocatePlayer", 1f);
    }
    
    private void Update()
    {
        currentState?.Update(this);
    }

    public void SetState(IEnemyState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    public string GetCurrentStateName()
    {
        return currentState != null ? currentState.GetType().Name.Replace("Enemy", "") : "No State";
    }
    
    private void OnEnable()
    {
        // TODO - add an animation event to play the spawn animation tween
        //scale the enemy up from 0 to 1 in 1 second using DOTween
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
    }

    // Method to handle taking damage (from player or other sources)
    public override void TakeDamage(int damage)
    {
        health -= damage;

        // Trigger the OnObjectDamaged event
        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, health);

        ShowHitEffect();

        if (health <= 0)
        {
            Die();

            // Trigger the OnObjectDestroyed event
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, health);
        }

        if(GetCurrentStateName() != "State_Chase")
        {
            SetState(new EnemyState_Angry());
        }
    }

    protected override void Die()
    {
        // Instantiate die effect and apply area damage
        if (dieEffectPrefab != null)
        {
            Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        }
        
        //TODO - add and audio feedback when the enemy dies
        //AudioEventManager.AudioEvent_PlaySFX(null, "Explosion Flesh", 1.0f, 1.0f, true, 0.1f, 0f, null);

        // Optional: add death logic, like spawning loot or playing an animation
        Destroy(gameObject);

        // Debug log to show that the enemy has died
        Debug.Log("Enemy has died");
        
        //increase the players score 
        GameManager.Instance.AddScore(10 * enemyData.health);
    }

    public override void Move()
    {
        // Do movement code here
    }

    // Method for the enemy to deal damage to another IDamagable object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the IDamagable interface
        IDamagable damagableObject = collision.gameObject.GetComponent<IDamagable>();
        // Prevent enemy from damaging other enemies (check the tag or another distinguishing property)
        if (damagableObject != null && collision.gameObject.tag != "Enemy")
        {
            // Call TakeDamage on the object, dealing the enemy's damage amount
            damagableObject.TakeDamage(damage);
            Debug.Log($"{gameObject.name} dealt {damage} damage to {collision.gameObject.name}.");
        }
    }

    private void LocatePlayer()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
