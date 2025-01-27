using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyAttributeSO enemyAttributeSO;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private FloatingHealthbar floatingHealthbar;
    [SerializeField] private UnityEvent died;
    [SerializeField] private UnityEvent<FloatingHealthbar, float, float> changedHealth;
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

        if (other.gameObject.tag == "Lighthit") {
            takeDamage(10);
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
            changedHealth?.Invoke(floatingHealthbar, enemyAttributeSO.health, currentHealth);
            yield return new WaitForSeconds(playerAttributesSO.tickSpeed);
        }
    }

    private void takeDamage(float amount) {
        currentHealth -= amount;
        changedHealth?.Invoke(floatingHealthbar, enemyAttributeSO.health, currentHealth);
    }

    private void dies() {
        player.GetComponent<CharacterMovement>().getXP(5);
        died?.Invoke();
        Destroy(gameObject);
    }
}
