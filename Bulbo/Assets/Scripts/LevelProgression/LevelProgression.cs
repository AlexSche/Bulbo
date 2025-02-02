using System.Collections;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    private static LevelProgression instance;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private SpawnerAttributeSO spawnerAttributeSO;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    [SerializeField] private EnemyControllerChannel enemyControllerChannel;
    private int currentLevel = 1;
    private int enemiesDied = 0;
    private int progessTreshhold = 20;
    void Awake()
    {
        // if instance exists, destroy the new instance, else create the singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        enemyControllerChannel.died += addDeadEnemey;
        StartCoroutine(progressLevel());
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

    public void resetEnemies()
    {
        currentLevel = 1;
        enemiesDied = 0;
    }
}
