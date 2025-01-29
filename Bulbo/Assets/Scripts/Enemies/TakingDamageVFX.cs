using UnityEngine;

public class TakingDamageVFX : MonoBehaviour
{
    [SerializeField] EnemyControllerChannel enemyControllerChannel;
    private bool isDead = false;

    void Start()
    {
        enemyControllerChannel.tookDamage += playTakingDamageVFX;
        enemyControllerChannel.died += stopPlayingVFX;
    }

    void playTakingDamageVFX(ParticleSystem particleSystem)
    {
        if (!isDead)
        {
            particleSystem.Play();
        }
    }

    void stopPlayingVFX(GameObject enemy, float xpWorth)
    {
        isDead = true;
        //Destroy(enemy);
    }
}
