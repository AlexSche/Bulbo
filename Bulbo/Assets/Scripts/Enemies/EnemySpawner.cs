using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(spawnEnemy(5, null));
    }

    IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        Debug.Log("create enemy");
    }
}
