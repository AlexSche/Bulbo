using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float aliveTimer = 10;
    private new Rigidbody rigidbody;
    private Vector3 destinationPoint;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, aliveTimer);
    }
    void Update()
    {
        if (destinationPoint != null)
        {
            if (Vector3.Distance(transform.position, destinationPoint) < 1)
            {
                rigidbody.linearVelocity = Vector3.zero;
            }
        }
    }

    public void setDestinationPosition(Vector3 position)
    {
        destinationPoint = position;
    }
}
