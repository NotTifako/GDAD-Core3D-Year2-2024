using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public int numberOfCollectibles = 10;

    int numberOfPowerUps = 3;
    public GameObject timerPowerUpPrefab;
    public GameObject speedPowerUpPrefab;

    public Vector3 spawnArea; // x, y, z (width, height, depth) of the spawn area (20, 0, 20)

    void Start()
    {
        SpawnCollectible();
        SpawnPowerUps();
    }

    void SpawnCollectible()
    {
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(0, spawnArea.y),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            Instantiate(collectiblePrefab, randomPosition, Quaternion.identity);
        }
    }

    void SpawnPowerUps()
    {
        for (int i = 0; i < numberOfPowerUps; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                Random.Range(0, spawnArea.y),
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );
            //int powerUpPrefabNumber = Random.Range(1,10);
            GameObject selectedPrefab;

            switch (i)
            {
                case 1:
                selectedPrefab = timerPowerUpPrefab;
                break;
                case 2:
                selectedPrefab = speedPowerUpPrefab;
                break;
                default:
                selectedPrefab = timerPowerUpPrefab;
                break;
            }

            Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}
