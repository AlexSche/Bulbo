using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FullScreenEffectController : MonoBehaviour
{
    private static FullScreenEffectController instance;
    [Header("References")]
    [SerializeField] private ScriptableRendererFeature fullScreenDamage;
    [SerializeField] private Material material;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;

    private float fadeOutTime = 0.5f;
    private int vignetteIntensity = Shader.PropertyToID("_VignetteIntensity");
    private const float VIGNETTE_INTENSITY_START_AMOUNT = 1;

        void Awake() {
        // make it singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start() {
        fullScreenDamage.SetActive(false);
        playerControllerChannel.healthChanged += startEffect;
    }

    void startEffect(float maxValue, float currentValue) {
        StartCoroutine(hurt());
    }

    IEnumerator hurt() {
        fullScreenDamage.SetActive(true);
        material.SetFloat(vignetteIntensity, VIGNETTE_INTENSITY_START_AMOUNT);
        yield return new WaitForSeconds(0.3f);
        float elapsedTime = 0f;
        while (elapsedTime < fadeOutTime) {
            elapsedTime += Time.deltaTime;
            float lerpedVignette = Mathf.Lerp(VIGNETTE_INTENSITY_START_AMOUNT, 0f, elapsedTime / fadeOutTime);
            material.SetFloat(vignetteIntensity, lerpedVignette);
            yield return 0;
        }
        fullScreenDamage.SetActive(false);
    }
}
