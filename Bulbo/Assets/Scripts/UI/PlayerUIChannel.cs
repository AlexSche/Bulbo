using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUIChannel", menuName = "Scriptable Objects/PlayerUIChannel")]
public class PlayerUIChannel : ScriptableObject
{
    public delegate void HealthChangedCallback(float maxValue, float currenctValue);
    public HealthChangedCallback healthChanged;

    public delegate void XPChangedCallback(float amountNeeded, float xpReceived);
    public XPChangedCallback xpChanged;

    public void changeHealth(float maxValue, float currenctValue) {
        healthChanged?.Invoke(maxValue, currenctValue);
    }

    public void changeXP(float amountNeeded, float xpReceived) {
        xpChanged?.Invoke(amountNeeded, xpReceived);
    }
}
