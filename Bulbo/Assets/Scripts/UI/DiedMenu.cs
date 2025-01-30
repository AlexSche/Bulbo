using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenu : MonoBehaviour
{
    public static DiedMenu instance;
    [SerializeField] GameObject deathMenu;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;

    void Awake()
    {
        // if instance exists, destroy the new instance, else create the singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        playerControllerChannel.playerDied += freezeGame;
        deathMenu.SetActive(false);
    }

    void freezeGame()
    {
        Time.timeScale = 0;
        deathMenu.SetActive(true);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathMenu.SetActive(false);
    }
}
