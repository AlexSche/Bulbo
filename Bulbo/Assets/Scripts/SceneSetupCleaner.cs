using UnityEngine;

public class SceneSetupCleaner : MonoBehaviour
{
    [SerializeField] PlayerHealthUI playerHealthUI;
    [SerializeField] PlayerXPUI playerXPUI;
    [SerializeField] LevelUI levelUI;
    [SerializeField] PlayerAttributesSO playerAttributesSO;
    public void correctlyDisplayUI() {
        playerHealthUI.changeHealthbar(playerAttributesSO.hitPoints, playerAttributesSO.hitPoints);
        playerXPUI.changeXPbar(playerAttributesSO.requiredXP, playerAttributesSO.xp);
        levelUI.setLevelToText();
    }
}
