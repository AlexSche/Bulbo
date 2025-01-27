using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerControllerChannel.healthChanged += changeHealthbar;
    }

    public void changeHealthbar(float maxValue, float currentValue)
    {
        slider.value = currentValue / maxValue;
    }
}
