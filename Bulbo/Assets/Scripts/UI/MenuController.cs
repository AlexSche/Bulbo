using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    private MainMenu mainMenu;
    private InputAction escPressed;
    private UnityEvent resume;
    void Start()
    {
        mainMenu = FindFirstObjectByType<MainMenu>();
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
        gameObject.SetActive(false);
        mainMenu.openMainMenu();
    }
}
