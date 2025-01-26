using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform[] bulletSpawnPoint;
    private GameObject player;
    private PlayerAttributesSO playerAttributesSO;
    public GameObject bulletPrefab;
    private float bulletSpeed = 10;
    private int alternatingNumber = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAttributesSO = player.GetComponent<CharacterMovement>().playerAttributesSO;
    }

    public void Shoot()
    {
        Transform chosenSpawnPoint = bulletSpawnPoint[alternatingNumber].transform;
        GameObject bullet = Instantiate(bulletPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = player.transform.forward * playerAttributesSO.bulletSpeed;
        changeNumber();
    }

    private void changeNumber() {
        if (alternatingNumber == 0) {
            alternatingNumber++;
        } else {
            alternatingNumber--;
        }
    }

}
