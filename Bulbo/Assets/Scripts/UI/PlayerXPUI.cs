using UnityEngine;
using UnityEngine.UI;

public class PlayerXPUI : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void changeXPbar(float maxValue, float currentValue)
    {
        slider.value = currentValue / maxValue;
    }
}
