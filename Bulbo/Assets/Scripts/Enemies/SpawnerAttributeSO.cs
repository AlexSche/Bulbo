using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerAttributeSO", menuName = "Scriptable Objects/SpawnerAttributeSO")]
public class SpawnerAttributeSO : ScriptableObject
{
    public float radius = 15f;
    public float spawnTimer = 10f;
    public int maxSpawner = 3;

    public void changeRadius(float amount) {
        radius += amount;
    }

    public void changeSpawnTimer(float amount) {
        spawnTimer += amount;
    }

    public void increaseMaxSpawner() {
        maxSpawner++;
    }
}
