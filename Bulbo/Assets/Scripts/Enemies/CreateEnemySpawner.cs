using System.Collections;
using UnityEngine;

public class CreateEnemySpawner : MonoBehaviour
{
    public float radius = 15f;
    public float spawnTimer = 5f;
    public int maxSpawner = 5;
    public GameObject enemySpawnerPrefab;
    private Vector3 center = Vector3.zero;

    void Start()
    {
        StartCoroutine(createNewSpawner());
    }

    private Vector3 determineSpawnLocation()
    {
        Vector3 direction = createRandomDirection();
        Vector3 spawnPos = Vector3.zero + direction;
        return spawnPos;
    }

    // creates a random direction in a 360 degree angle
    private Vector3 createRandomDirection()
    {
        int randomAngle = Random.Range(0, 361);
        Vector3 direction = new Vector3(radius * Mathf.Cos(randomAngle), 0, radius * Mathf.Sin(randomAngle));
        return direction;
    }

    IEnumerator createNewSpawner()
    {
        for (int i = 0; i < maxSpawner; i++)
        {
            GameObject enemySpawner = Instantiate(enemySpawnerPrefab, determineSpawnLocation(), Quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
