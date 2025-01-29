using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] MainMenu mainMenu;
    private InputAction escPressed;
    void Start()
    {
        gameObject.SetActive(false);
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

    public void returnToMainMenu() {
        mainMenu.openMainMenu();
    }
}
