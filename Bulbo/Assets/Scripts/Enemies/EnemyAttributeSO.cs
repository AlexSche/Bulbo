using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributeSO", menuName = "Scriptable Objects/EnemyAttributeSO")]
public class EnemyAttributeSO : ScriptableObject
{
    public int health = 100;
    public int speed = 20;
    public int attackDamage = 5;
    public int xpWorth = 5;
}
