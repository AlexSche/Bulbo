using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    private InputAction escPressed;

    void Awake() {
        escPressed = playerInput.actions.FindAction("OpenMenu");
        escPressed.performed += _ => freezeGame();
    }

    void freezeGame()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
