// Gives access to MonoBehaviour and other Unity types
using UnityEngine;

// The parent class of every ship in the game
// abstract: Ship is never used on its own, only through Player and Enemy
public abstract class Ship : MonoBehaviour, IDamageable
{
    // How fast the ship moves, editable in the Inspector
    [SerializeField] private float moveSpeed = 5f;
    // Health the ship starts with
    [SerializeField] private int startingHealth = 100;
    // Damage each of this ship's bullets does
    [SerializeField] private int damage = 10;
    // The bullet prefab this ship fires
    [SerializeField] private Bullet bulletPrefab;

    // This ship's health; made in Awake
    private Health health;
    // This ship's weapon; protected so Player and Enemy can fire it
    protected Weapon weapon;

    // Runs once when the object is created, before any Start
    private void Awake()
    {
        // new calls Health's constructor with this ship's starting health
        health = new Health(startingHealth);
        // "this is Player" is true on the player and false on every enemy, so the weapon knows its side
        weapon = new Weapon(bulletPrefab, damage, this is Player);
    }

    // Moves the ship this frame in the direction passed in
    public void Move(Vector2 direction)
    {
        Move(direction, 1f);
    }

    public void Move(Vector2 direction, float speedMult)
    {
        transform.Translate(direction * moveSpeed *  speedMult * Time.deltaTime);
    }


    // abstract: no body here; Player and Enemy must each write their own Shoot
    public abstract void Shoot();

    // Lowers this ship's health by the amount passed in
    public void TakeDamage(int amount)
    {
        // Only Health changes its own value (encapsulation)
        health.DeductHealth(amount);
        // Show the result in the Console
        Debug.Log(name + " took " + amount + " damage, health is now " + health.GetCurrentHealth());

        // Out of health: remove the ship
        if (health.IsEmpty())
        {
            Die();
        }
    }

    // Removes the ship from the game; virtual so a child class can add to it
    public virtual void Die()
    {
        // Destroy the GameObject this script is on
        Destroy(gameObject);
    }
}