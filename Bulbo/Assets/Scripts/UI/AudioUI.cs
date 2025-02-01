using UnityEngine;

public class AudioUI : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void openSettings()
    {
        gameObject.SetActive(true);
    }

    public void closeSettings()
    {
        gameObject.SetActive(false);
    }
}
