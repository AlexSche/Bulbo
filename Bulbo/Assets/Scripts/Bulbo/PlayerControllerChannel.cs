using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControllerChannel", menuName = "Scriptable Objects/PlayerControllerChannel")]
public class PlayerControllerChannel : ScriptableObject
{
    public delegate void LevelChangedCallback();
    public LevelChangedCallback levelChanged;

    public delegate void HealthChangedCallback(float maxValue, float currenctValue);
    public HealthChangedCallback healthChanged;

    public delegate void XPChangedCallback(float amountNeeded, float xpReceived);
    public XPChangedCallback xpChanged;

    public void changeHealth(float maxValue, float currenctValue)
    {
        healthChanged?.Invoke(maxValue, currenctValue);
    }

    public void changeXP(float amountNeeded, float xpReceived)
    {
        xpChanged?.Invoke(amountNeeded, xpReceived);
    }

    public void changeLevel()
    {
        levelChanged?.Invoke();
    }
}
