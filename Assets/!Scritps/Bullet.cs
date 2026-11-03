// Gives access to MonoBehaviour and other Unity types
using UnityEngine;

// A bullet fired by any ship; its own MonoBehaviour, not a Ship
public class Bullet : MonoBehaviour
{
    // How fast the bullet flies, editable in the Inspector
    [SerializeField] private float speed = 10f;
    // Seconds before the bullet removes itself
    [SerializeField] private float lifetime = 2f;
    // Which way it flies; set by the weapon that fires it
    private Vector2 direction;
    // Damage it does; set by the weapon that fires it
    private int damage;
    // True if the player fired it; set by the weapon that fires it
    private bool firedByPlayer;

    // Runs once when the bullet appears
    private void Start()
    {
        // Remove the bullet after lifetime seconds so missed shots don't pile up
        Destroy(gameObject, lifetime);
    }

    // Runs every frame
    private void Update()
    {
        // Fly in the bullet's direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Called by Weapon right after spawning the bullet
    public void Launch(Vector2 newDirection, int newDamage, bool newFiredByPlayer)
    {
        // Store which way to fly
        direction = newDirection;
        // Store how much damage to do
        damage = newDamage;
        // Store which side fired it
        firedByPlayer = newFiredByPlayer;
    }

    // Runs when this bullet's trigger collider overlaps another collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Look for a Ship on whatever was hit (Player, Bee and Butterfly are all Ships)
        Ship target = other.GetComponent<Ship>();

        // Not a ship (like another bullet): ignore it
        if (target == null)
        {
            return;
        }

        // Same side as the shooter (the player's own ship, or an enemy hitting an enemy): ignore it
        if ((target is Player) == firedByPlayer)
        {
            return;
        }

        // A ship on the other side: deal the damage
        OccurDamage(target);
    }

    // Damages the ship this bullet hit
    public void OccurDamage(Ship target)
    {
        // Any Ship can be hit: the player or any enemy
        target.TakeDamage(damage);
        // The bullet is used up
        Destroy(gameObject);
    }
}