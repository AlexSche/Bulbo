using System.Collections;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject projectileSpawnPosition;
    public override IEnumerator moveEnemy()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, targetPosition) > 8f && !isDead)
            {
                Vector2 moveDirection = targetPosition - transform.position;
                transform.LookAt(targetPosition);
                animator.SetBool("isMoving", true);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyAttributeSO.speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                shootAtCurrentPlayerPosition(targetPosition);
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void shootAtCurrentPlayerPosition(Vector3 currentPlayerPosition)
    {
        Debug.Log("Shooting!!! at: " + currentPlayerPosition);
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPosition.transform.position, transform.rotation);
        Projectile projectileSkript = projectile.GetComponent<Projectile>();
        projectileSkript.shootAtPosition(currentPlayerPosition);
    }
}
