using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject healthPotionPrefab;
    public GameObject manaPotionPrefab;
    public GameObject funPotionPrefab;

    public int numberOfItemsEachSide = 5;
    public float spacing = 2.0f;

    void Start()
    {
        SpawnHealthPotions();
        SpawnMoreHealthPotions();
        SpawnManaPotions();
        SpawnMoreManaPotions();
        SpawnFunPotions();
    }

    void SpawnHealthPotions()
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            Vector3 position = new Vector3(i * spacing, -0.5f, -4);

            GameObject newHealthPotion = Instantiate(healthPotionPrefab, position, Quaternion.identity);

            HealthPotion healthPotionItem = newHealthPotion.GetComponent<HealthPotion>();
            if (healthPotionItem != null)
            {
                healthPotionItem.DisplayInfo();
            }
            else
            {
                Debug.LogWarning("The instantiated health potion does not have the HealthPotion component!");
            }
        }
    }

    void SpawnMoreHealthPotions()
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            Vector3 position = new Vector3(i * spacing, -0.5f, 4);

            GameObject newHealthPotion = Instantiate(healthPotionPrefab, position, Quaternion.identity);

            HealthPotion healthPotionItem = newHealthPotion.GetComponent<HealthPotion>();
            if (healthPotionItem != null)
            {
                healthPotionItem.DisplayInfo();
            }
            else
            {
                Debug.LogWarning("The instantiated health potion does not have the HealthPotion component!");
            }
        }
    }

    void SpawnManaPotions()
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            Vector3 position = new Vector3(i * spacing, -0.5f, -8.0f);

            GameObject newManaPotion = Instantiate(manaPotionPrefab, position, Quaternion.identity);

            ManaPotion manaPotionItem = newManaPotion.GetComponent<ManaPotion>();
            if (manaPotionItem != null)
            {
                manaPotionItem.DisplayInfo();
            }
            else
            {
                Debug.LogWarning("The instantiated mana potion does not have the ManaPotion component!");
            }
        }
    }
    
    void SpawnMoreManaPotions()
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            Vector3 position = new Vector3(i * spacing, -0.5f, 8.0f);

            GameObject newManaPotion = Instantiate(manaPotionPrefab, position, Quaternion.identity);

            ManaPotion manaPotionItem = newManaPotion.GetComponent<ManaPotion>();
            if (manaPotionItem != null)
            {
                manaPotionItem.DisplayInfo();
            }
            else
            {
                Debug.LogWarning("The instantiated mana potion does not have the ManaPotion component!");
            }
        }
    }

    void SpawnFunPotions()
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            Vector3 position = new Vector3(i * spacing, -0.5f, 0);

            GameObject newFunPotion = Instantiate(funPotionPrefab, position, Quaternion.identity);

            FunPotion funPotionItem = newFunPotion.GetComponent<FunPotion>();
            if (funPotionItem != null)
            {
                funPotionItem.DisplayInfo();
            }
            else 
            {
                Debug.LogWarning("The instantiated fun potion does not have the FunPotion component!");
            }
        }
    }
}
