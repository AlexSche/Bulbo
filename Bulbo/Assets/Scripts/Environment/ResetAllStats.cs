using UnityEngine;

public class ResetAllStats : MonoBehaviour
{
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private SpawnerAttributeSO spawnerAttributeSO;

    public void resetStats()
    {
        playerAttributesSO.resetAllStats();
        spawnerAttributeSO.resetAllStats();
    }

    public void resetSpawner()
    {
        spawnerAttributeSO.resetAllStats();
    }
}
