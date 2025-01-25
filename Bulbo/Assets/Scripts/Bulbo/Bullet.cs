using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float aliveTimer = 3;

    void Awake() {
        Destroy(gameObject, aliveTimer);
    }
}
