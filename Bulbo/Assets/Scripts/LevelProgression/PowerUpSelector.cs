using System.Collections;
using TMPro;
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
        if (playerAttributesSO.level % 3 == 0)
        {
            if (playerAttributesSO.level == 3)
            {
                selectFixedPowerUp(0);
                return;
            }
            if (playerAttributesSO.level == 6)
            {
                selectFixedPowerUp(1);
                return;
            }
            selectPowerUp();
        }
    }
}
