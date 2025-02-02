using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    [SerializeField] private EnemyAttributeSO enemyAttributeSO;
    private float travelTime = 10f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void shootAtPosition(Vector3 position)
    {
        StartCoroutine(travelingToPosition(position));
    }


    IEnumerator travelingToPosition(Vector3 targetPosition)
    {
        targetPosition.y = transform.position.y;
        Vector3 direction = targetPosition - transform.position;
        targetPosition = targetPosition + (direction);
        float elapsedTime = 0f;
        while (elapsedTime < travelTime)
        {
            elapsedTime += Time.deltaTime * 0.01f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / travelTime);
            yield return new WaitForEndOfFrame();
            if (Vector3.Distance(transform.position, player.transform.position) < 1f)
            {
                playerControllerChannel.attackedByEnemy?.Invoke(enemyAttributeSO.attackDamage);
                Destroy(gameObject);
            }
            if (Vector3.Distance(transform.position, targetPosition) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
