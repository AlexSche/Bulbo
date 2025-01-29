using System.Collections;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private SpawnerAttributeSO spawnerAttributeSO;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    [SerializeField] private EnemyControllerChannel enemyControllerChannel;
    private int currentLevel = 1;
    private int enemiesDied = 0;
    private int progessTreshhold = 20;
    void Start()
    {
        playerControllerChannel.levelChanged += increaseStats;
        enemyControllerChannel.died += addDeadEnemey;
        StartCoroutine(progressLevel());
    }

    void increaseStats()
    {
        playerAttributesSO.changeHitpoints(10);
        playerAttributesSO.changeBulletAliveTimer(1);
        playerAttributesSO.changeDamage(1);
        playerAttributesSO.changeCharacterSpeed(1);
        playerAttributesSO.reduceReloadSpeed(0.1f);
        playerAttributesSO.changeBulletLightRadius(1);
    }

    void addDeadEnemey(GameObject enemy, float xpWorth)
    {
        enemiesDied++;
    }

    IEnumerator progressLevel()
    {
        while (true)
        {
            if (enemiesDied >= progessTreshhold)
            {
                increaseProgressThresh();
                increaseDifficulty();
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void increaseProgressThresh()
    {
        currentLevel++;
        progessTreshhold *= 3;
    }

    private void increaseDifficulty()
    {
        spawnerAttributeSO.defaultEnemies += 2;
        if (currentLevel % 2 == 0)
        {
            spawnerAttributeSO.eliteEnemies += 1;
        }
        if (currentLevel % 5 == 0)
        {
            //spawn chargers
        }
        spawnerAttributeSO.changeSpawnTimer(-0.05f);
    }
}
