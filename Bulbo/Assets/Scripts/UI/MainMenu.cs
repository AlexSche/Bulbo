using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void openMainMenu()
    {
        gameObject.SetActive(true);
    }

    public void startGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void reloadScene() {
        //string currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
