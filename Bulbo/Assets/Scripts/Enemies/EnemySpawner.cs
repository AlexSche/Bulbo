using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(spawnEnemy(5, enemyPrefab));
    }

    IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        Vector3 spawnPosition = transform.position;
        GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
