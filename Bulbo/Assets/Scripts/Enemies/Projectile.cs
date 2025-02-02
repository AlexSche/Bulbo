using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float travelTime = 100f;

    public void shootAtPosition(Vector3 position)
    {
        StartCoroutine(travelingToPosition(position));
    }


    IEnumerator travelingToPosition(Vector3 targetPosition)
    {
        targetPosition.y = transform.position.y;
        float elapsedTime = 0f;
        while (elapsedTime < travelTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / travelTime);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
