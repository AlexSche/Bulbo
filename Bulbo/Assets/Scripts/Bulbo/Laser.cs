using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 destinationPoint;
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, destinationPoint) >= 1.2f)
        {
            moveWithFixedY();
        } else {
            Destroy(gameObject);
        }
    }

    public void moveWithFixedY()
    {
        Vector3 dir = (destinationPoint - transform.position);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        dir.y = transform.position.y;
        transform.position += dir * 5 * Time.deltaTime;
    }

    public void setDestinationPosition(Vector3 position)
    {
        destinationPoint = position;
    }
}
