using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject pauseMenu;
    private InputAction escPressed;

    void Awake() {
        // if instance exists, destroy the new instance, else create the singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        escPressed = playerInput.actions.FindAction("OpenMenu");
        escPressed.performed += _ => freezeGame();
    }

    void freezeGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
