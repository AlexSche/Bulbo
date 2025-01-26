using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(spawnEnemy(5, null));
    }

    IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        Debug.Log("create enemy");
    }
}
