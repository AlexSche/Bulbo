using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool reloadedScene = false;
    [SerializeField] private GameObject pauseMenu;
    public void Awake()
    {
        reloadedScene = false;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void openMainMenu()
    {
        gameObject.SetActive(true);
    }

    public void startGame()
    {
        if (reloadedScene)
        {
            reloadScene();
        }
        else
        {
            pauseMenu.SetActive(false);
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
