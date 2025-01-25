using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform[] bulletSpawnPoint;
    public GameObject player;
    public GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 10;
    private int alternatingNumber = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Shoot()
    {
        Transform chosenSpawnPoint = bulletSpawnPoint[alternatingNumber].transform;
        GameObject bullet = Instantiate(bulletPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = player.transform.forward * bulletSpeed;
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
