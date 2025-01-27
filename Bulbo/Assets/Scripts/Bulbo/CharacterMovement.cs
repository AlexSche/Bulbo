using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private EnemyControllerChannel enemyControllerChannel;
    //[SerializeField] private ShootingBar shootingBar;
    [SerializeField] private UnityEvent<float, float> onHealthChanged;
    [SerializeField] private UnityEvent<float, float> onXPChanged;
    [SerializeField] private UnityEvent onLevelChanged;
    PlayerInput playerInput;
    InputAction moveAction;
    public PlayerAttributesSO playerAttributesSO;
    private LookAtCursor lookAtCursor;
    private Gun gun;
    private Animator animator;
    private CharacterController characterController;
    private float completeShootAnimationSpeed = 0;
    private float shootTimer = 0;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        lookAtCursor = GetComponent<LookAtCursor>();
        gun = GetComponent<Gun>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        enemyControllerChannel.died += getXP;

        moveAction = playerInput.actions.FindAction("Move");

        StartCoroutine(automaticShooting(playerAttributesSO.reloadSpeed));
    }

    void Update()
    {
        if (shootTimer >= 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (characterController.velocity.magnitude <= 0.1)
        {
            animator.SetBool("isWalking", false);
        }
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(moveDirection.x, 0, moveDirection.y);
        characterController.Move(moveDir * playerAttributesSO.characterSpeed * Time.deltaTime);
        if (characterController.velocity.magnitude > 0.1)
        {
            animator.SetBool("isWalking", true);
        }
        //transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * playerAttributesSO.characterSpeed * Time.deltaTime;
    }

    public IEnumerator automaticShooting(float duration)
    {
        while (true)
        {
            completeShootAnimationSpeed = duration + (animator.GetCurrentAnimatorStateInfo(0).length * 4/6);
            shootTimer = completeShootAnimationSpeed;
            yield return new WaitForSeconds(duration);
            animator.SetBool("isShooting", true);
            //gun.shootAtPosition(lookAtCursor.mousePos); added Event in animation
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            animator.SetBool("isShooting", false);
        }
    }

    public void shooting()
    {
        gun.shootAtPosition(lookAtCursor.mousePos);
    }

    public void takeDamage(int damage) {
        onHealthChanged?.Invoke(playerAttributesSO.hitPoints, playerAttributesSO.hitPoints-damage);
        playerAttributesSO.changeHitpoints(-damage);
    }

    public void getXP(GameObject enemy, float xp) {
        playerAttributesSO.xp += xp;
        if (playerAttributesSO.xp >= playerAttributesSO.requiredXP) {
            playerAttributesSO.levelUp();
            onLevelChanged?.Invoke();
        }
        onXPChanged?.Invoke(playerAttributesSO.requiredXP, playerAttributesSO.xp);
    }
}
