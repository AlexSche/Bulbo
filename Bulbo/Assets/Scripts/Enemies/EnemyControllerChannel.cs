using UnityEngine;

[CreateAssetMenu(fileName = "EnemyControllerChannel", menuName = "Scriptable Objects/EnemyControllerChannel")]
public class EnemyControllerChannel : ScriptableObject
{
    public delegate void HealthChangedCallback(FloatingHealthbar healthbar, float maxValue, float currentValue);
    public HealthChangedCallback healthChanged;

    public delegate void DiedCallback();
    public DiedCallback died;


    public void changeHealth(FloatingHealthbar healthbar, float maxValue, float currentValue)
    {
        healthChanged?.Invoke(healthbar, maxValue, currentValue);
    }

    public void enemyDied()
    {
        died?.Invoke();
    }
}
