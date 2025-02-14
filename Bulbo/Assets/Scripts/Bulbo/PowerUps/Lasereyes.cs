using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Lasereyes : MonoBehaviour
{
    public Transform[] laserSpawnPoint;
    public GameObject LaserPrefab;
    [SerializeField] private PowerUpSO powerUpSO;
    [SerializeField] private CreateEnemySpawner enemySpawner;
    public UnityEvent laserEyesActived;

    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(activateLaser());
        //laserEyesActived.AddListener(activateLaser);
    }

    IEnumerator activateLaser()
    {
        while (true)
        {
            if (powerUpSO.isActive)
            {
                for (int i = 0; i < powerUpSO.amount; i++)
                {
                    StartCoroutine(shootLasersAtClosestEnemy());
                    yield return new WaitForSeconds(0.7f);
                }
            }
            yield return new WaitForSeconds(5f);
        }
    }

    public GameObject findClosestEnemy()
    {
        orderEnemiesByDistance();
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;
        if (enemySpawner.enemies.Count > 0)
        {
            enemySpawner.enemies.ForEach((enemy) =>
            {
                float checkDistance = Vector3.Distance(player.transform.position, enemy.transform.position);
                if (checkDistance <= closestDistance)
                {
                    Debug.Log("only have to do this once since sorted");
                    closestEnemy = enemy;
                    closestDistance = Vector3.Distance(player.transform.position, enemy.transform.position);
                }
            });
        }
        return closestEnemy;
    }

    public List<Vector3> findXClosestEnemies(int numberOfRicochets)
    {
        orderEnemiesByDistance();
        List<Vector3> positions = new List<Vector3>();
        while (enemySpawner.enemies.Count < numberOfRicochets)
        {
            numberOfRicochets--;
        }
        if (enemySpawner.enemies.Count > 0)
        {
            List<GameObject> enemies = enemySpawner.enemies.GetRange(0, numberOfRicochets);
            enemies.ForEach(enemy =>
            {
                positions.Add(enemy.transform.position);
            });
        }
        return positions;
    }

    public void orderEnemiesByDistance()
    {
        enemySpawner.enemies.Sort((enemy1, enemy2) =>
        {
            if (Vector3.Distance(enemy1.transform.position, player.transform.position) < Vector3.Distance(enemy2.transform.position, player.transform.position))
            {
                return -1;
            }
            else if (Vector3.Distance(enemy1.transform.position, player.transform.position) > Vector3.Distance(enemy2.transform.position, player.transform.position))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        });
    }

    IEnumerator shootLasersAtClosestEnemy()
    {
        List<Vector3> positions = findXClosestEnemies(powerUpSO.ricochets);
        if (positions.Count > 0)
        {
            Transform chosenSpawnPoint = laserSpawnPoint[0].transform;
            chosenSpawnPoint.LookAt(positions[0]);
            if (Vector3.Distance(chosenSpawnPoint.position, positions[0]) <= powerUpSO.radius)
            {
                GameObject laser = Instantiate(LaserPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
                Laser laserScript = laser.GetComponent<Laser>();
                laserScript.setDestinationPosition(positions[0]);
                laserScript.setDestinationPositions(positions);
            }
        }
        yield return null;
    }

}
