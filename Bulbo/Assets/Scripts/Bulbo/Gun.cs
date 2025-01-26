using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform[] bulletSpawnPoint;
    private GameObject player;
    private PlayerAttributesSO playerAttributesSO;
    public GameObject bulletPrefab;
    private int alternatingNumber = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAttributesSO = player.GetComponent<CharacterMovement>().playerAttributesSO;
    }

    public void shootAtPosition(Vector3 position)
    {
        Transform chosenSpawnPoint = bulletSpawnPoint[alternatingNumber].transform;
        chosenSpawnPoint.LookAt(position);

        GameObject bullet = Instantiate(bulletPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.setDestinationPosition(position);
        Vector3 direction = position - chosenSpawnPoint.position;
        bullet.GetComponent<Rigidbody>().linearVelocity = direction * playerAttributesSO.bulletSpeed;
        changeNumber();
    }

    private void changeNumber()
    {
        if (alternatingNumber == 0)
        {
            alternatingNumber++;
        }
        else
        {
            alternatingNumber--;
        }
    }

}
