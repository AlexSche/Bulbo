using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerAttributesSO playerAttributesSO;
    private new Rigidbody rigidbody;
    private Vector3 destinationPoint;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (destinationPoint != null)
        {
            if (Vector3.Distance(transform.position, destinationPoint) < 0.4f)
            {
                rigidbody.linearVelocity = Vector3.zero;
                StartCoroutine(removeBullet());
            }
        }
    }

    public void setDestinationPosition(Vector3 position)
    {
        destinationPoint = position;
    }

    IEnumerator removeBullet() {
        yield return new WaitForSeconds(playerAttributesSO.bulletAliveTimer);
        Destroy(gameObject);
    }
}
