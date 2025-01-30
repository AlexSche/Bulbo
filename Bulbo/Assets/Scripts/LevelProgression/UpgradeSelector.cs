using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSelector : MonoBehaviour
{
    private static UpgradeSelector instance;
    [SerializeField] private UpgradeSO[] upgradeSOs;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    [SerializeField] private TMP_Text[] upgradeTexts;
    private List<int> foundNumbers = new List<int>();

    void Awake() {
        // make it singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start() {
        playerControllerChannel.levelChanged += selectUpgrades;
    }

    void selectUpgrades()
    {
        int zeroOneTwo = 0;
        while (foundNumbers.Count < 3)
        {
            int randomNumber = Random.Range(0, upgradeSOs.Length);
            if (!foundNumbers.Contains(randomNumber))
            {
                //Debug.Log("Found this upgrade number: " + randomNumber);
                //Debug.Log("Displaying: " + randomNumber + "at position: " + zeroOneTwo);
                foundNumbers.Add(randomNumber);
                displayUpgradesInUI(zeroOneTwo);
                zeroOneTwo++;
            }
        }
    }

    void displayUpgradesInUI(int i) {
        upgradeTexts[i].text = upgradeSOs[foundNumbers[i]].description;
    }

    public void upgradeSelected(int i) {
        upgradeSOs[foundNumbers[i]].upgrade?.Invoke();
        resetList();
    }

    public void resetList() {
        foundNumbers = new List<int>();
    }
}
