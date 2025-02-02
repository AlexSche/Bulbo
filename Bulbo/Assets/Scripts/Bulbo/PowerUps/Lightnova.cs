using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Lightnova : MonoBehaviour
{
    [SerializeField] private GameObject lightNovaPrefab;
    [SerializeField] private PowerUpSO powerUpSO;
    private GameObject player;
    private Vector3 castOnPosition = Vector3.zero;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(activateLightNova());
    }

    IEnumerator activateLightNova()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSO.cooldown);
            if (powerUpSO.isActive)
            {
                for (int i = 0; i < powerUpSO.amount; i++)
                {
                    StartCoroutine(castLightNova());
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
    }

    IEnumerator castLightNova()
    {
        Vector3 castOnPosition = new Vector3(Random.Range(0, 15), 15, Random.Range(0, 15));
        GameObject lightNova = Instantiate(lightNovaPrefab, castOnPosition, Quaternion.Euler(90, 0, 0));
        Light light = lightNova.GetComponent<Light>();
        SphereCollider sphereCollider = lightNova.GetComponent<SphereCollider>();
        while (light.spotAngle < powerUpSO.radius * 10)
        {
            light.spotAngle += 0.05f;
            if (sphereCollider.radius * 10 < light.spotAngle)
            {
                sphereCollider.radius += 0.05f / 10;
            }
            yield return new WaitForNextFrameUnit();
        }
        Destroy(lightNova);
    }
}
