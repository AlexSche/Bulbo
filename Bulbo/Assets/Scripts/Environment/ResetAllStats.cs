using UnityEngine;

public class ResetAllStats : MonoBehaviour
{
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private SpawnerAttributeSO spawnerAttributeSO;
    [SerializeField] private PowerUpSO laserEyesSO;
    [SerializeField] private PowerUpSO lightNovaSO;
    [SerializeField] private LevelProgression levelProgression;

    public void resetStats()
    {
        playerAttributesSO.resetAllStats();
        spawnerAttributeSO.resetAllStats();
        levelProgression.resetEnemies();
        laserEyesSO.resetPowerUp();
        lightNovaSO.resetPowerUp();
    }

    public void resetSpawner()
    {
        spawnerAttributeSO.resetAllStats();
        levelProgression.resetEnemies();
    }
}
