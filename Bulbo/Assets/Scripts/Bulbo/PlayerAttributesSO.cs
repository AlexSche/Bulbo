using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributesSO", menuName = "Scriptable Objects/PlayerAttributesSO")]
public class PlayerAttributesSO : ScriptableObject
{
    public int hitPoints = 100;
    public int level = 1;
    public float xp = 0;
    public float requiredXP = 35;
    public float damage = 20;
    public float tickSpeed = 1;
    public float characterSpeed = 2;
    public float bulletSpeed = 5;
    public float bulletAliveTimer = 10;
    public float bulletLightRadius = 2;
    public float reloadSpeed = 1;
    public float lightRadius = 5;


    public void changeHitpoints(int amount)
    {
        hitPoints += amount;
    }

    public void reduceReloadSpeed(float amount)
    {
        Debug.Log(reloadSpeed);
        reloadSpeed = reloadSpeed - amount;
        Debug.Log("New Reloadspeed: " + reloadSpeed);
    }

    public void changeLightRaidus(float amount)
    {
        lightRadius += amount;
    }

    public void changeCharacterSpeed(float amount)
    {
        characterSpeed += amount;
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

    public void changeTickSpeed(float amount)
    {
        tickSpeed += amount;
    }

    public void increaseXP(float amount)
    {
        xp += amount;
    }

    public void levelUp()
    {
        if (xp >= requiredXP)
        {
            level++;
            xp = requiredXP - xp;
            requiredXP = level * 35;
        }
    }

    public void resetAllStats() {
    hitPoints = 100;
    level = 1;
    xp = 0;
    requiredXP = 35;
    damage = 20;
    tickSpeed = 2;
    characterSpeed = 2;
    bulletSpeed = 5;
    bulletAliveTimer = 10;
    bulletLightRadius = 2;
    reloadSpeed = 2;
    lightRadius = 15;
    }
}
