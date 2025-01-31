using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] AudioSource audioSourceUI;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void playUIClick()
    {
        audioSourceUI.Play();
    }

    public void playUpgradeSelected() {
        audioSourceUI.Play();
    }
}
