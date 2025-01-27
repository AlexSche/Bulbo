using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Lasereyes : MonoBehaviour
{
    public Transform[] bulletSpawnPoint;
    public GameObject LaserPrefab;
    [SerializeField] private PowerUpSO powerUpSO;
    [SerializeField] private CreateEnemySpawner enemySpawner;

    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(shootLasersAtClosestEnemy());
    }

    public void shootAtClosestEnemy()
    {
        GameObject closestEnemy = findClosestEnemy();
        Transform chosenSpawnPoint = bulletSpawnPoint[0].transform;
        chosenSpawnPoint.LookAt(closestEnemy.transform.position);
        Debug.DrawLine(chosenSpawnPoint.position, closestEnemy.transform.position, Color.cyan, 10);
        /*
        GameObject bullet = Instantiate(LaserPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        */
    }

    public GameObject findClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;
        if (enemySpawner.enemies.Count > 0)
        {
            enemySpawner.enemies.ForEach((enemy) =>
            {   
                float checkDistance = Vector3.Distance(player.transform.position, enemy.transform.position);
                if (checkDistance <= closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = Vector3.Distance(player.transform.position, enemy.transform.position);
                }
            });
        }
        return closestEnemy;
    }

    IEnumerator shootLasersAtClosestEnemy()
    {
        while (true)
        {
            GameObject closestEnemy = findClosestEnemy();
            if (closestEnemy != null)
            {
                Transform chosenSpawnPoint = bulletSpawnPoint[0].transform;
                chosenSpawnPoint.LookAt(closestEnemy.transform.position);
                Debug.DrawLine(chosenSpawnPoint.position, closestEnemy.transform.position, Color.cyan, 10);
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
