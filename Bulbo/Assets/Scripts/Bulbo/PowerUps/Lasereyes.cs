using UnityEngine;

public class Lasereyes : MonoBehaviour
{
    public Transform[] bulletSpawnPoint;
    public GameObject LaserPrefab;
    [SerializeField] private PowerUpSO powerUpSO;

    public void shootAtPosition(Vector3 position)
    {
        Transform chosenSpawnPoint = bulletSpawnPoint[0].transform;
        chosenSpawnPoint.LookAt(position);
        GameObject bullet = Instantiate(LaserPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        chosenSpawnPoint = bulletSpawnPoint[1].transform;
        chosenSpawnPoint.LookAt(position);
        GameObject bullet2 = Instantiate(LaserPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
    }
}
