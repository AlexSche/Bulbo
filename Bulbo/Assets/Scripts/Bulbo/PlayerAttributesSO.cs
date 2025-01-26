using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributesSO", menuName = "Scriptable Objects/PlayerAttributesSO")]
public class PlayerAttributesSO : ScriptableObject
{
    public int hitPoints;
    public float damage;
    public float tickSpeed;
    public float characterSpeed;
    public float bulletSpeed;
    public float bulletAliveTimer;
    public float bulletLightRadius;
    public float reloadSpeed;
    public float lightRaidus;


    public void changeHitpoints(int amount)
    {
        hitPoints += amount;
    }

    public void changeReloadSpeed(float amount)
    {
        reloadSpeed += amount;
    }

    public void changeLightRaidus(float amount)
    {
        lightRaidus += amount;
    }

    public void changeCharacterSpeed(float amount)
    {
        reloadSpeed += amount;
    }

    public void changeBulletSpeed(float amount)
    {
        bulletSpeed += amount;
    }

    public void changeBulletAliveTimer(float amount)
    {
        bulletAliveTimer += amount;
    }

    public void changeBulletLightRadius(float amount)
    {
        bulletLightRadius += amount;
    }

    public void changeDamage(float amount)
    {
        damage += amount;
    }

    public void changeTickSpeed(float amount) {
        tickSpeed += amount;
    }
}
