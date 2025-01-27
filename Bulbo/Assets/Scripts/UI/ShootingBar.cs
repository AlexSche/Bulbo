using UnityEngine;
using UnityEngine.UI;

public class ShootingBar : MonoBehaviour
{
    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
    }

    public void changeBarStatus(float maxValue, float currenctValue) {
        slider.value = 1 - (currenctValue / maxValue);
    }
}
