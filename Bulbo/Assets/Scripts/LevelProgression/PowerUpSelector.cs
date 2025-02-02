using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpSelector : MonoBehaviour
{
    private static PowerUpSelector instance;
    [SerializeField] private UpgradeSO[] powerUpSOs;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    [SerializeField] private TMP_Text powerUpAnnouncement;

    void Awake()
    {
        // make it singleton
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
        playerControllerChannel.levelChanged += addPowerUp;

    }

    void selectPowerUp()
    {
        int randomNumber = Random.Range(2, powerUpSOs.Length);
        powerUpSOs[randomNumber].upgrade?.Invoke();
        StartCoroutine(displayUpgradesInUI(randomNumber));
    }

    void selectFixedPowerUp(int i)
    {
        powerUpSOs[i].upgrade?.Invoke();
        StartCoroutine(displayUpgradesInUI(i));
    }

    IEnumerator displayUpgradesInUI(int i)
    {
        powerUpAnnouncement.text = powerUpSOs[i].description;
        yield return new WaitForSeconds(5f);
        powerUpAnnouncement.text = "";
    }

    public void addPowerUp()
    {
        if (playerAttributesSO.level % 5 == 0)
        {
            if (playerAttributesSO.level == 5)
            {
                selectFixedPowerUp(0);
                Debug.Log("Added Eyes");
                return;
            }
            if (playerAttributesSO.level == 10)
            {
                selectFixedPowerUp(1);
                Debug.Log("Added Nova");
                return;
            }
            Debug.Log("Added random Powerup!!!");
        }
    }
}
