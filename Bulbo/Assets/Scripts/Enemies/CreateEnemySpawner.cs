using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private GameObject slimeEnemy;
    [SerializeField] private GameObject redSlimeEnemy;
    [SerializeField] private EnemyControllerChannel enemyControllerChannel;
    public SpawnerAttributeSO spawnerAttributeSO;
    private Vector3 center = Vector3.zero;

    void Start()
    {
        enemyControllerChannel.died += enemyRemoved;
        StartCoroutine(spawnEnemy());
    }

    private Vector3 determineSpawnLocation(Vector3 position, int radius)
    {
        Vector3 direction = createRandomDirection(radius);
        Vector3 spawnPos = position + direction;
        return spawnPos;
    }

    // creates a random direction in a 360 degree angle
    private Vector3 createRandomDirection(int radius)
    {
        int randomAngle = Random.Range(0, 361);
        Vector3 direction = new Vector3(radius * Mathf.Cos(randomAngle), 0, radius * Mathf.Sin(randomAngle));
        return direction;
    }

    IEnumerator spawnEnemy()
    {
        while (true)
        {
            Vector3 spawnPos = determineSpawnLocation(Vector3.zero, spawnerAttributeSO.radius);
            for (int i = 0; i < spawnerAttributeSO.defaultEnemies; i++)
            {
                if (i % 4 == 0)
                {
                    spawnPos = determineSpawnLocation(Vector3.zero, spawnerAttributeSO.radius);
                }
                Vector3 enemySpawnPos = determineSpawnLocation(spawnPos, 4);
                GameObject spawnedEnemy = Instantiate(slimeEnemy, enemySpawnPos, Quaternion.identity);
                enemies.Add(spawnedEnemy);
            }
            for (int i = 0; i < spawnerAttributeSO.eliteEnemies; i++)
            {
                if (i % 4 == 0)
                {
                    spawnPos = determineSpawnLocation(Vector3.zero, spawnerAttributeSO.radius);
                }
                Vector3 enemySpawnPos = determineSpawnLocation(spawnPos, 4);
                GameObject spawnedEnemy = Instantiate(redSlimeEnemy, enemySpawnPos, Quaternion.identity);
                enemies.Add(spawnedEnemy);
            }
            yield return new WaitForSeconds(spawnerAttributeSO.spawnTimer);
        }
    }

    private void enemyRemoved(GameObject enemy, float xpWorth)
    {
        enemies.Remove(enemy);
    }
}
