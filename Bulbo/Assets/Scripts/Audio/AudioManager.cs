using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] PlayerControllerChannel playerControllerChannel;
    [SerializeField] EnemyControllerChannel enemyControllerChannel;
    [SerializeField] AudioSource audioSourceUI;
    [SerializeField] AudioSource audioSourceGameTheme;
    [SerializeField] AudioSource audioSourcePlayerDamaged;
    [SerializeField] AudioSource audioSourcePlayerDied;
    [SerializeField] AudioSource audioSourcePlayerLightAttack;
    [SerializeField] AudioSource audioSourceEnemyDamaged;
    [SerializeField] AudioSource audioSourceEnemyDied;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        playerControllerChannel.healthChanged += playPlayerDamaged;
        playerControllerChannel.playerDied += playPlayerDied;
        enemyControllerChannel.tookDamage += playEnemyDamaged;
        enemyControllerChannel.died += playEnemyDied;
    }

    private void playPlayerDamaged(float maxValue, float currentValue) {
        audioSourcePlayerDamaged.Play();
    }

    private void playPlayerDied() {
        audioSourcePlayerDied.Play();
        audioSourceGameTheme.Stop();
    }

    private void playEnemyDamaged() {
        audioSourceEnemyDamaged.Play();
    }

    private void playEnemyDied(GameObject enemy, float xpWorth) {
        audioSourceEnemyDied.Play();
    }

    public void playMainTheme() {
        audioSourceGameTheme.Play();
    }
    public void stopMainTheme() {
        audioSourceGameTheme.Stop();
    }

    public void playUIClick()
    {
        audioSourceUI.Play();
    }

    public void playUpgradeSelected() {
        audioSourceUI.Play();
    }
}
