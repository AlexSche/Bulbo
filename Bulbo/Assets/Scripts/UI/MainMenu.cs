using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool reloadedScene = false;
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
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void reloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
