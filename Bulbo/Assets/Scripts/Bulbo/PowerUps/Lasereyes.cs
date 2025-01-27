using UnityEngine;

public class Lasereyes : Gun
{
    [SerializeField] private PowerUpSO powerUpSO;

    public void shootAtPosition(Vector3 position)
    {
        Transform chosenSpawnPoint = bulletSpawnPoint[0].transform;
        chosenSpawnPoint.LookAt(position);
        GameObject bullet = Instantiate(bulletPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        chosenSpawnPoint = bulletSpawnPoint[1].transform;
        chosenSpawnPoint.LookAt(position);
        GameObject bullet2 = Instantiate(bulletPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
    }
}
