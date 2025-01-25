using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CharacterMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    [SerializeField]
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer() 
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(moveDirection.x, 0 , moveDirection.y) * speed * Time.deltaTime;
    }
}
