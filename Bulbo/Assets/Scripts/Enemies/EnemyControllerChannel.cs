using UnityEngine;

[CreateAssetMenu(fileName = "EnemyControllerChannel", menuName = "Scriptable Objects/EnemyControllerChannel")]
public class EnemyControllerChannel : ScriptableObject
{
    public delegate void HealthChangedCallback(FloatingHealthbar healthbar, float maxValue, float currentValue);
    public HealthChangedCallback healthChanged;

    public delegate void EnemySpawnedCallback(GameObject enemy);
    public EnemySpawnedCallback enemySpawned;

    public delegate void DiedCallback(GameObject enemy, float xpWorth);
    public DiedCallback died;

    public delegate void TookDamageCallback(ParticleSystem particleSystem);
    public TookDamageCallback tookDamage;


    public void changeHealth(FloatingHealthbar healthbar, float maxValue, float currentValue)
    {
        healthChanged?.Invoke(healthbar, maxValue, currentValue);
    }

    public void enemySpawner(GameObject enemy) {
        enemySpawned?.Invoke(enemy);
    }

    public void enemyDied(GameObject enemy, float xpWorth)
    {
        died?.Invoke(enemy, xpWorth);
    }

    public void enemyTookDamage(ParticleSystem particleSystem) {
        tookDamage?.Invoke(particleSystem);
    }
}
