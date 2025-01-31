using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyAttributeSO enemyAttributeSO;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private PowerUpSO laserEyesSO, LightnovaSO;
    [SerializeField] private FloatingHealthbar floatingHealthbar;
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private Shader dissolveShader;
    private int dissolveAmount = Shader.PropertyToID("_DissolveAmount");
    [SerializeField] private UnityEvent<GameObject, float> died;
    [SerializeField] private UnityEvent<FloatingHealthbar, float, float> changedHealth;
    [SerializeField] private UnityEvent<GameObject> spawned;
    [SerializeField] private UnityEvent tookDamage;
    [SerializeField] private UnityEvent<int> attackedPlayer;
    private GameObject player;
    private float currentHealth;
    private float speed;
    private float attackDamage;
    private Animator animator;
    private Vector3 targetPosition = Vector3.zero;
    private Coroutine damageCoroutine = null;
    private bool isDead = false;
    private bool isDissolving = false;

    void Awake()
    {
        spawned?.Invoke(this.gameObject);
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        currentHealth = enemyAttributeSO.health;
        speed = enemyAttributeSO.speed;
        attackDamage = enemyAttributeSO.attackDamage;
        StartCoroutine(moveEnemy());
    }

    void Update()
    {
        if (currentHealth <= 1)
        {
            if (isDead && !isDissolving)
            {
                StartCoroutine(dissolve());
            }
        }
    }

    void FixedUpdate()
    {
        targetPosition = player.transform.position;
    }

    IEnumerator moveEnemy()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 1f && !isDead)
        {
            Vector2 moveDirection = targetPosition - transform.position;
            transform.LookAt(targetPosition);
            animator.SetBool("isMoving", true);
            //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f * (1 - (enemyAttributeSO.speed / 100)));
            //yield return new WaitForSeconds(0.4f);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemyAttributeSO.speed * Time.deltaTime);
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lightradius")
        {
            damageCoroutine = StartCoroutine(damageOverTime());
        }
        if (other.gameObject.tag == "Lighthit")
        {
            takeDamage(LightnovaSO.damage);
        }
        if (other.gameObject.tag == "Laserhit")
        {
            takeDamage(laserEyesSO.damage);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attackedPlayer?.Invoke(enemyAttributeSO.attackDamage);
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
            takeDamage(playerAttributesSO.damage);
            yield return new WaitForSeconds(playerAttributesSO.tickSpeed);
        }
    }

    private void takeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth > 0)
        {
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
            //changedHealth?.Invoke(floatingHealthbar, enemyAttributeSO.health, currentHealth);
            tookDamage?.Invoke();
        }
        else
        {
            changedHealth?.Invoke(floatingHealthbar, enemyAttributeSO.health, 0);
            die();
        }
    }

    private void die()
    {
        if (!isDead)
        {
            died?.Invoke(gameObject, enemyAttributeSO.xpWorth);
        }
        isDead = true;
    }

    IEnumerator dissolve()
    {
        isDissolving = true;
        Material[] mats = gameObject.GetComponentInChildren<Renderer>().materials.ToArray();
        float elapsedTime = 0f;
        float dissolveTime = 1.2f;
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(0, 1.1f, elapsedTime / dissolveTime);
            for (int i = 0; i < mats.Length; i++)
            {

                mats[i].shader = dissolveShader;
                mats[i].SetFloat(dissolveAmount, lerpedDissolve);
            }
            yield return null;
        }
        Destroy(gameObject);
    }
}
