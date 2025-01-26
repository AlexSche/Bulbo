using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyAttributeSO enemyAttributeSO;
    [SerializeField] private FloatingHealthbar floatingHealthbar;
    private float currentHealth;
    private float speed;
    private float attackDamage;
    private Vector3 targetPosition = Vector3.zero;
    void Start()
    {
        currentHealth = enemyAttributeSO.health;
        speed = enemyAttributeSO.speed;
        attackDamage = enemyAttributeSO.attackDamage;
        StartCoroutine(moveEnemy());
    }

    void FixedUpdate() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
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
            StartCoroutine(damageOverTime(10, 1));
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Lightradius") {
            StopCoroutine(damageOverTime(10, 1));
        }
    }

    private IEnumerator damageOverTime(float damage, float tick) {
        while (true) {
            currentHealth -= damage;
            floatingHealthbar.updateHealthbar(currentHealth, enemyAttributeSO.health);
            yield return new WaitForSeconds(tick);
        }
    }
}
