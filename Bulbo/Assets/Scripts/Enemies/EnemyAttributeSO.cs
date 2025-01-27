using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttributeSO", menuName = "Scriptable Objects/EnemyAttributeSO")]
public class EnemyAttributeSO : ScriptableObject
{
    public float health = 100;
    public float speed = 20;
    public float attackDamage = 5;
    public float xpWorth = 5;
}
