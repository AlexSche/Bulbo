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
        StartCoroutine(castLightNova(powerUpSO.cooldown)); // only here for Debugging
    }

    public void activateLightNova()
    {
        StartCoroutine(castLightNova(powerUpSO.cooldown));
    }

    IEnumerator castLightNova(float duration)
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            Vector3 castOnPosition = new Vector3(player.transform.position.x, 15, player.transform.position.z);
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
}
