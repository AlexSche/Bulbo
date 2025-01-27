using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyAttributeSO enemyAttributeSO;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private FloatingHealthbar floatingHealthbar;
    private GameObject player;
    private float currentHealth;
    private float speed;
    private float attackDamage;
    private Animator animator;
    private Vector3 targetPosition = Vector3.zero;
    private Coroutine damageCoroutine = null;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        currentHealth = enemyAttributeSO.health;
        speed = enemyAttributeSO.speed;
        attackDamage = enemyAttributeSO.attackDamage;
        StartCoroutine(moveEnemy());
    }

    void FixedUpdate()
    {
        targetPosition = player.transform.position;
        if (currentHealth <= 0)
        {
            dies();
        }
    }

    IEnumerator moveEnemy()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 1f)
        {
            Vector2 moveDirection = targetPosition - transform.position;
            transform.LookAt(targetPosition);
            animator.SetBool("isMoving", true);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.025f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lightradius")
        {
            damageCoroutine = StartCoroutine(damageOverTime());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lightradius")
        {
            StopCoroutine(damageCoroutine);
        }
    }

    private IEnumerator damageOverTime()
    {
        while (true)
        {
            currentHealth -= playerAttributesSO.damage;
            floatingHealthbar.updateHealthbar(currentHealth, enemyAttributeSO.health);
            yield return new WaitForSeconds(playerAttributesSO.tickSpeed);
        }
    }

    private void dies() {
        player.GetComponent<CharacterMovement>().getXP(5);
        Destroy(gameObject);
    }
}
