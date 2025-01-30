using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{

    [SerializeField] private TMP_Text upgrade1TMP;
    [SerializeField] private TMP_Text upgrade2TMP;
    [SerializeField] private TMP_Text upgrade3TMP;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;

    void Awake()
    {
        playerControllerChannel.levelChanged += openUI;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void openUI()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true);
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
        gameObject.SetActive(false);
    }
}
