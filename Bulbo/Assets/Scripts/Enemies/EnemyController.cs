using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected EnemyAttributeSO enemyAttributeSO;
    [SerializeField] protected PlayerAttributesSO playerAttributesSO;
    [SerializeField] protected EnemyControllerChannel enemyControllerChannel;
    [SerializeField] protected PlayerControllerChannel playerControllerChannel;
    [SerializeField] protected PowerUpSO laserEyesSO, LightnovaSO;
    [SerializeField] protected FloatingHealthbar floatingHealthbar;
    [SerializeField] protected new ParticleSystem particleSystem;
    [SerializeField] protected Shader dissolveShader;
    protected int dissolveAmount = Shader.PropertyToID("_DissolveAmount");
    protected GameObject player;
    protected float currentHealth;
    protected float speed;
    protected float attackDamage;
    protected Animator animator;
    protected Vector3 targetPosition = Vector3.zero;
    protected Coroutine damageCoroutine = null;
    protected bool isDead = false;
    protected bool isDissolving = false;

    void Awake()
    {
        enemyControllerChannel.enemySpawned?.Invoke(this.gameObject);
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

    public virtual IEnumerator moveEnemy()
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
            playerControllerChannel.attackedByEnemy?.Invoke(enemyAttributeSO.attackDamage);
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
            enemyControllerChannel.tookDamage?.Invoke();
        }
        else
        {
            enemyControllerChannel.healthChanged?.Invoke(floatingHealthbar, enemyAttributeSO.health, 0);
            die();
        }
    }

    private void die()
    {
        if (!isDead)
        {
            enemyControllerChannel.died?.Invoke(gameObject, enemyAttributeSO.xpWorth);
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
