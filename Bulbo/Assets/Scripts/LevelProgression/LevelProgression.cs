using System.Collections;
using TMPro;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    private static LevelProgression instance;
    [SerializeField] private TMP_Text zoneLevel;
    [SerializeField] private TMP_Text killCount;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private SpawnerAttributeSO spawnerAttributeSO;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    [SerializeField] private EnemyControllerChannel enemyControllerChannel;
    private int currentLevel = 1;
    private int enemiesDied = 0;
    private int progessTreshhold = 14;
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
        killCount.text = "Kills: " + enemiesDied;
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
        zoneLevel.text = "Zone: " + currentLevel;
    }

    private void increaseDifficulty()
    {
        spawnerAttributeSO.defaultEnemies += 2;
        if (currentLevel % 3 == 0)
        {
            spawnerAttributeSO.eliteEnemies += 1;
        }
        if (currentLevel % 2 == 0)
        {
            int amount = Random.Range(1, 3);
            spawnerAttributeSO.rangedEnemies += amount;
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
        zoneLevel.text = "Zone: " + currentLevel;
        killCount.text = "Kills: " + enemiesDied;
    }
}
