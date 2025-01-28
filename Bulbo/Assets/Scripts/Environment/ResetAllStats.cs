using UnityEngine;

public class ResetAllStats : MonoBehaviour
{
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private PlayerAttributesSO defaultPlayerAttributesSO;
    [SerializeField] private SpawnerAttributeSO spawnerAttributeSO;
    [SerializeField] private SpawnerAttributeSO defaultSpawnerAttributeSO;

    public void resetStats() {
        playerAttributesSO = defaultPlayerAttributesSO;
        spawnerAttributeSO = defaultSpawnerAttributeSO;
    }
}
