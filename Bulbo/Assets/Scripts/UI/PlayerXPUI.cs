using UnityEngine;
using UnityEngine.UI;

public class PlayerXPUI : MonoBehaviour
{
    [SerializeField] private PlayerUIChannel playerUIChannel;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerUIChannel.xpChanged += changeXPbar;
    }

    public void changeXPbar(float amountNeeded, float xpReceived)
    {
        slider.value = xpReceived / amountNeeded;
    }
}
