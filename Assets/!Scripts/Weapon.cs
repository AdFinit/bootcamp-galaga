
// Gives access to Unity types like Vector2 and Vector3
using UnityEngine;



// A plain C# class: spawns bullets for the ship that owns it
// Not a MonoBehaviour, so it is created with new inside Ship
public class Weapon
{
    // The bullet prefab this weapon spawns
    private Bullet bulletPrefab;
    // Damage each bullet does
    private int damage;
    // True if the player owns this weapon, false if an enemy does
    private bool ownedByPlayer;

    // Constructor: runs when new Weapon(...) is called and stores what it was given
    public Weapon(Bullet newBulletPrefab, int newDamage, bool newOwnedByPlayer)
    {
        // Keep the prefab to spawn later
        bulletPrefab = newBulletPrefab;
        // Keep the damage to hand to each bullet
        damage = newDamage;
        // Keep which side this weapon is on, to hand to each bullet
        ownedByPlayer = newOwnedByPlayer;
    }

    // Spawns a bullet at a position, flying in a direction
    public void Shoot(Vector3 position, Vector2 direction)
    {
        // Object.Instantiate works in a plain class too; it makes a copy of the prefab
        Bullet bullet = Object.Instantiate(bulletPrefab, position, Quaternion.identity);
        // Tell the new bullet which way to fly, how much damage it does, and which side fired it
        bullet.Launch(direction, damage, ownedByPlayer);
    }
}