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
    private Gun gun;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        gun = GetComponent<Gun>();

        moveAction = playerInput.actions.FindAction("Move");
        attackAction = playerInput.actions.FindAction("Attack");

        attackAction.performed += _ => gun.Shoot();
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
