using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerAttributeSO", menuName = "Scriptable Objects/SpawnerAttributeSO")]
public class SpawnerAttributeSO : ScriptableObject
{
    public int radius = 15;
    public int spawnTimer = 5;
    public int defaultEnemies = 4;
    public int eliteEnemies = 0;

    public void changeRadius(int amount) {
        radius += amount;
    }

    public void changeSpawnTimer(int amount) {
        spawnTimer += amount;
    }
}
