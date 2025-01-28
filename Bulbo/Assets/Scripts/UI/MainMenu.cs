using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameObject player;
    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Time.timeScale = 0;
        player.SetActive(false);
        gameObject.SetActive(true);
    }

    public void openMainMenu()
    {
        gameObject.SetActive(true);
    }

    public void startGame()
    {
        gameObject.SetActive(false);
        player.SetActive(true);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
