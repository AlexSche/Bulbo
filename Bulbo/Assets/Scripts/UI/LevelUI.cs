using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text level_text;
    [SerializeField] private PlayerControllerChannel playerControllerChannel;
    [SerializeField] private PlayerAttributesSO playerAttributesSO;
    private static string level = "Lvl: ";
    private string currentLevel;

    void Start () {
        setLevelToText();
        playerControllerChannel.levelChanged += setLevelToText;
    }

    public void setLevelToText() {
        currentLevel = playerAttributesSO.level.ToString();
        string displayText = level + currentLevel;
        level_text.text = displayText;
    }
}
