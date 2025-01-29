using UnityEngine;

public class TakingDamageVFX : MonoBehaviour
{
    [SerializeField] EnemyControllerChannel enemyControllerChannel;
    private bool isDead = false;

    void Start()
    {
        enemyControllerChannel.tookDamage += playTakingDamageVFX;
        enemyControllerChannel.died += playDieingVFX;
    }

    void playTakingDamageVFX(ParticleSystem particleSystem)
    {
        if (!isDead)
        {
            particleSystem.Play();
        }
    }

    void playDieingVFX(GameObject enemy, float xpWorth)
    {
        isDead = true;
        Debug.Log("DIED");
        GameObject.Destroy(enemy);
    }
}
