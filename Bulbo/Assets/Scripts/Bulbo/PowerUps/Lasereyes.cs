using System.Collections;
using UnityEngine;

public class Lasereyes : MonoBehaviour
{
    public Transform[] laserSpawnPoint;
    public GameObject LaserPrefab;
    [SerializeField] private PowerUpSO powerUpSO;
    [SerializeField] private CreateEnemySpawner enemySpawner;

    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(shootLasersAtClosestEnemy());
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
                Transform chosenSpawnPoint = laserSpawnPoint[0].transform;
                chosenSpawnPoint.LookAt(closestEnemy.transform.position);
                //Debug.DrawLine(chosenSpawnPoint.position, closestEnemy.transform.position, Color.cyan, 10);
                if (Vector3.Distance(chosenSpawnPoint.position, closestEnemy.transform.position) <= powerUpSO.radius)
                {
                    GameObject laser = Instantiate(LaserPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
                    Laser laserScript = laser.GetComponent<Laser>();
                    laserScript.setDestinationPosition(closestEnemy.transform.position);
                }
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
