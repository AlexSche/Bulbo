using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpSO", menuName = "Scriptable Objects/PowerUpSO")]
public class PowerUpSO : ScriptableObject
{
    public float cooldown = 10f;
    public float radius = 5f;
    public float damage = 20f;
    public int ricochets = 0;
    public bool isActive = false;

    [HideInInspector]
    public void changeCooldown(float amount)
    {
        cooldown += amount;
    }

    public void changeRadius(float amount)
    {
        radius += amount;
    }
    public void changeDamage(float amount)
    {
        damage += amount;
    }

    public void increaseRicochets()
    {
        ricochets++;
    }

    public void activatePowerup() {
        isActive = true;
    }

    public void resetPowerUp() {
        isActive = false;
        radius = 5f;
        damage = 50f;
        ricochets = 1;
    }
}
