using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CharacterMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    InputAction attackAction;
    private float speed;
    public PlayerAttributesSO playerAttributesSO;
    private LookAtCursor lookAtCursor;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        lookAtCursor = GetComponent<LookAtCursor>();

        moveAction = playerInput.actions.FindAction("Move");
        attackAction = playerInput.actions.FindAction("Attack");

        //attackAction.performed += _ => lookAtCursor.shootAtMouse();
        StartCoroutine(lookAtCursor.automaticShooting(playerAttributesSO.reloadSpeed));
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer() 
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(moveDirection.x, 0 , moveDirection.y) * playerAttributesSO.characterSpeed * Time.deltaTime;
    }
}
