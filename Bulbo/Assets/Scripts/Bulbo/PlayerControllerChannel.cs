using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControllerChannel", menuName = "Scriptable Objects/PlayerControllerChannel")]
public class PlayerControllerChannel : ScriptableObject
{
    public delegate void LevelChangedCallback();
    public LevelChangedCallback levelChanged;

    public delegate void HealthChangedCallback(float maxValue, float currentValue);
    public HealthChangedCallback healthChanged;

    public delegate void XPChangedCallback(float amountNeeded, float xpReceived);
    public XPChangedCallback xpChanged;

    public delegate void AttackedByEnemyCallback(int damage);
    public AttackedByEnemyCallback attackedByEnemy;

    public delegate void PlayerDiedCallback();
    public PlayerDiedCallback playerDied;

    public void changeHealth(float maxValue, float currentValue)
    {
        healthChanged?.Invoke(maxValue, currentValue);
        if (currentValue <= 0) {
            playerDied?.Invoke();
        }
    }

    public void changeXP(float amountNeeded, float xpReceived)
    {
        xpChanged?.Invoke(amountNeeded, xpReceived);
    }

    public void changeLevel()
    {
        levelChanged?.Invoke();
    }
    
    public void enemyAttacked(int damage) {
        attackedByEnemy?.Invoke(damage);
    }
}
