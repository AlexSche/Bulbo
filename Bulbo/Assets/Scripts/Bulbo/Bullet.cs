using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerAttributesSO playerAttributesSO;
    private new Light light;
    private SphereCollider capsuleCollider;
    private Vector3 destinationPoint;

    void Start() {
        light = GetComponent<Light>();
        capsuleCollider = GetComponent<SphereCollider>();

        light.range = playerAttributesSO.bulletLightRadius;
        light.intensity = playerAttributesSO.bulletLightRadius;
        capsuleCollider.radius = playerAttributesSO.bulletLightRadius * 4;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, destinationPoint) >= 1.2f)
        {
            moveWithFixedY();
        } else {
            StartCoroutine(removeBullet());
        }

    }

    public void moveWithFixedY()
    {
        Vector3 dir = (destinationPoint - transform.position);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        dir.y = transform.position.y;
        transform.position += dir * playerAttributesSO.bulletSpeed * Time.deltaTime;
    }

    public void setDestinationPosition(Vector3 position)
    {
        destinationPoint = position;
    }

    IEnumerator removeBullet()
    {
        yield return new WaitForSeconds(playerAttributesSO.bulletAliveTimer / 2);
        for (int i = 0; i <= playerAttributesSO.bulletAliveTimer; i++) {
            light.range -= light.range/20;
            light.intensity -= light.intensity/20;
            capsuleCollider.radius -= capsuleCollider.radius/10;
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
