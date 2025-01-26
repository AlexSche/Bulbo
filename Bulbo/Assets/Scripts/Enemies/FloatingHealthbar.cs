using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    private Slider slider;
    private new Camera camera;


    void Start() {
        slider = GetComponent<Slider>();
        camera = Camera.main;
    }

    void Update() {
        transform.rotation = camera.transform.rotation;
    }

    public void updateHealthbar(float currentValue, float maxValue) {
        slider.value = currentValue/maxValue;
    }
}
