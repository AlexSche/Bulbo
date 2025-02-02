using UnityEngine;

public class PlayerLightRadius : MonoBehaviour
{
    [SerializeField] private new Light light;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;

    void Start() {
        light = GetComponent<Light>();
    }

    void FixedUpdate()
    {
        changeLightRadius();
    }

    public void changeLightRadius() {
        if (light != null) {
            light.spotAngle = playerAttributesSO.lightRadius;
        }
    }
}
