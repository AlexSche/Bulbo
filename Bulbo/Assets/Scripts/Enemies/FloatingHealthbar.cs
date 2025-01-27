using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] EnemyControllerChannel enemyControllerChannel;
    private Slider slider;
    private new Camera camera;


    void Start() {
        slider = GetComponent<Slider>();
        camera = Camera.main;
        enemyControllerChannel.healthChanged += updateHealthbar;
    }

    void Update() {
        transform.rotation = camera.transform.rotation;
    }

    public void updateHealthbar(FloatingHealthbar floatingHealthbar, float maxValue, float currentValue) {
        floatingHealthbar.slider.value = currentValue/maxValue;
    }
}
