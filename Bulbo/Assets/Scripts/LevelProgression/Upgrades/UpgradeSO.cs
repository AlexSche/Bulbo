using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public string description;
    public UnityEvent upgrade;
}
