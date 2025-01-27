using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 destinationPoint;
    private List<Vector3> destinationPositions = new List<Vector3>();
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, destinationPoint) >= 0.5f)
        {
            moveWithFixedY();
        }
        else
        {
            if (destinationPositions.Count > 0)
            {
                destinationPoint = destinationPositions[0];
                destinationPositions.RemoveAt(0);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void moveWithFixedY()
    {
        Vector3 dir = (destinationPoint - transform.position);
        transform.position = new Vector3(transform.position.x, 0.25f, transform.position.z);
        dir.y = transform.position.y;
        transform.position += dir * 5 * Time.deltaTime;
    }

    public void setDestinationPosition(Vector3 position)
    {
        destinationPoint = position;
    }

    public void setDestinationPositions(List<Vector3> positions)
    {
        destinationPositions = positions;
    }
}
