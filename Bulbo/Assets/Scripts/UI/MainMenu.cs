using UnityEngine;

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

    public void ExitGame()
    {
        Application.Quit();
    }
}
