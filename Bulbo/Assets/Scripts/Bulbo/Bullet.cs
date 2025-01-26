using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerAttributesSO playerAttributesSO;
    private Vector3 destinationPoint;

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, destinationPoint) >= 1.2f)
        {
            moveWithFixedY();
        } else {
            StartCoroutine(removeBullet());
        }

    }

    public void moveWithFixedY()
    {
        Vector3 dir = (destinationPoint - transform.position);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        dir.y = transform.position.y;
        transform.position += dir * playerAttributesSO.bulletSpeed * Time.deltaTime;
    }

    public void setDestinationPosition(Vector3 position)
    {
        destinationPoint = position;
    }

    IEnumerator removeBullet()
    {
        yield return new WaitForSeconds(playerAttributesSO.bulletAliveTimer);
        Destroy(gameObject);
    }
}
