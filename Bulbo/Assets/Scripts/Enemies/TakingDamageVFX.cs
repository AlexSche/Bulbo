using UnityEngine;

public class TakingDamageVFX : MonoBehaviour
{
    [SerializeField] EnemyControllerChannel enemyControllerChannel;

    void Start() {
        enemyControllerChannel.tookDamage += playTakingDamageVFX;
    }

    void playTakingDamageVFX(ParticleSystem particleSystem) {
        particleSystem.Play();
    }
}
