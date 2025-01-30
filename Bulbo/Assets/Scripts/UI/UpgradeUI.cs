using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public static UpgradeUI instance;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private TMP_Text upgrade1TMP;
    [SerializeField] private TMP_Text upgrade2TMP;
    [SerializeField] private TMP_Text upgrade3TMP;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;

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
        playerControllerChannel.levelChanged += openUI;
    }

    void Start()
    {
        upgradeUI.SetActive(false);
    }

    public void openUI()
    {
        if (upgradeUI != null)
        {
            upgradeUI.SetActive(true);
            Time.timeScale = 0;
            setUI();
        }
    }

    public void setUI()
    {
        upgrade1TMP.text = "TEST!";
        upgrade2TMP.text = "NEUES!";
        upgrade3TMP.text = "UPGRADE!";
    }

    public void upgradeSelected()
    {
        Time.timeScale = 1;
        Debug.Log("Selected Upgrade 1!!!");
        upgradeUI.SetActive(false);
    }
}
