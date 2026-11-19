using UnityEngine;

public class WeaponReader : MonoBehaviour
{
    [SerializeField] private WeaponStats weapon;

    void Start()
    {
        Debug.Log(weapon.Describe());
    }
}
