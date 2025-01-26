using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributesSO", menuName = "Scriptable Objects/PlayerAttributesSO")]
public class PlayerAttributesSO : ScriptableObject
{
    public int hitPoints;
    public float characterSpeed;
    public float bulletSpeed;
    public float bulletAliveTimer;
    public float reloadSpeed;
    public float lightRaidus;


    public void changeHitpoints(int amount) {
        hitPoints += amount;
    }

    public void changeReloadSpeed(float amount) {
        reloadSpeed += amount;
    }

    public void changeLightRaidus(float amount) {
        lightRaidus += amount;
    }

    public void changeCharacterSpeed(float amount) {
        reloadSpeed += amount;
    }

    public void changeBulletSpeed(float amount) {
        bulletSpeed += amount;
    }

    public void changeBulletAliveTimer(float amount) {
        bulletAliveTimer += amount;
    }
}
