using UnityEngine;
using UnityEngine.UI;

public class PlayerXPUI : MonoBehaviour
{
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerControllerChannel.xpChanged += changeXPbar;
    }

    public void changeXPbar(float amountNeeded, float xpReceived)
    {
        slider.value = xpReceived / amountNeeded;
    }
}
