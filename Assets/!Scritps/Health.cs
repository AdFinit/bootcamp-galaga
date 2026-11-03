// A plain C# class: keeps track of one ship's health
// Not a MonoBehaviour, so it is created with new inside Ship
public class Health
{
    // Health right now; private so only Health can change it
    private int currentHealth;

    // Constructor: runs when new Health(...) is called
    public Health(int startingHealth)
    {
        // Start at the health that was passed in
        currentHealth = startingHealth;
    }

    // Lowers health by the amount passed in
    public void DeductHealth(int amount)
    {
        // Take the amount away
        currentHealth -= amount;
        // Never go below 0 (encapsulation keeps the value valid)
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    // Lets other classes read the value without being able to change it
    public int GetCurrentHealth()
    {
        // Hand back the current value
        return currentHealth;
    }

    // True when there is no health left
    public bool IsEmpty()
    {
        // Compare and hand back true or false
        return currentHealth == 0;
    }
}