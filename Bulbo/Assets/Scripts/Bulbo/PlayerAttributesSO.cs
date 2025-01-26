using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributesSO", menuName = "Scriptable Objects/PlayerAttributesSO")]
public class PlayerAttributesSO : ScriptableObject
{
    public int hitPoints;
    public float characterSpeed;
    public float bulletSpeed;
    public float reloadSpeed;
    public float lightRaidus;


    public void increaseHitpoints(int amount) {
        hitPoints += amount;
    }

    public void increaseReloadSpeed(float amount) {
        reloadSpeed += amount;
    }

    public void increaseLightRaidus(float amount) {
        lightRaidus += amount;
    }

    public void increaseCharacterSpeed(float amount) {
        reloadSpeed += amount;
    }

    public void increaseBulletSpeed(float amount) {
        bulletSpeed += amount;
    }
}
