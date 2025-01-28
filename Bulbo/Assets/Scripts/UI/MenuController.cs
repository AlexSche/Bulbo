using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameObject menu;
    private InputAction escPressed;
    private UnityEvent resume;
    void Start()
    {
        menu.SetActive(false);
        escPressed = playerInput.actions.FindAction("OpenMenu");
        escPressed.performed += _ => freezeGame();
    }

    void freezeGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}
