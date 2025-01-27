using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private EnemyControllerChannel enemyControllerChannel;
    public SpawnerAttributeSO spawnerAttributeSO;
    private Vector3 center = Vector3.zero;

    void Start()
    {
        enemyControllerChannel.died += enemyRemoved;
        StartCoroutine(spawnEnemy(enemyPrefab));
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
        Vector3 direction = new Vector3(spawnerAttributeSO.radius * Mathf.Cos(randomAngle), 0, spawnerAttributeSO.radius * Mathf.Sin(randomAngle));
        return direction;
    }

    IEnumerator spawnEnemy(GameObject enemy)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnerAttributeSO.spawnTimer);
            Vector3 spawnPosition = transform.position;
            GameObject spawnedEnemy = Instantiate(enemy, determineSpawnLocation(), Quaternion.identity);
            enemies.Add(spawnedEnemy);
        }
    }

    private void enemyRemoved(GameObject enemy, float xpWorth)
    {
        enemies.Remove(enemy);
    }
}
