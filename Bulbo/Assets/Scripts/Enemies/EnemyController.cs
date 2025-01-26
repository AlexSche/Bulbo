using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 targetPosition = Vector3.zero;
    void Start()
    {
        StartCoroutine(moveEnemy());
    }

    IEnumerator moveEnemy()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 1f)
        {
            Vector2 moveDirection = targetPosition - transform.position;
            transform.LookAt(Vector3.zero);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
            yield return new WaitForSeconds(1);
        }
    }
}
