using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Scriptable Objects/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private int damage;
    [SerializeField] private float timeBetweenShots;

    public string Describe()
    {
        return weaponName + ": " + damage + " damage, one shot every " + timeBetweenShots + " seconds";
    }
}
