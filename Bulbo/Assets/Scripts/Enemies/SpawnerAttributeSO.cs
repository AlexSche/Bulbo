using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerAttributeSO", menuName = "Scriptable Objects/SpawnerAttributeSO")]
public class SpawnerAttributeSO : ScriptableObject
{
    public int radius = 15;
    public float spawnTimer = 5;
    public int defaultEnemies = 4;
    public int eliteEnemies = 0;
    public int rangedEnemies = 0;

    public void changeRadius(int amount)
    {
        radius += amount;
    }

    public void changeSpawnTimer(float amount)
    {
        spawnTimer += amount;
    }

    public void resetAllStats()
    {
        radius = 15;
        spawnTimer = 5;
        defaultEnemies = 4;
        eliteEnemies = 0;
        rangedEnemies = 0;
    }
}
