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

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Lightradius") {
            Debug.Log("Enemy takes damage");
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Lightradius") {
            Debug.Log("Enemy no longer takes damage");
        }
    }
}
