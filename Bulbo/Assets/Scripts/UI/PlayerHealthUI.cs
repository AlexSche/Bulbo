using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerUIChannel playerUIChannel;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerUIChannel.healthChanged += changeHealthbar;
    }

    public void changeHealthbar(float maxValue, float currentValue)
    {
        slider.value = currentValue / maxValue;
    }
}
