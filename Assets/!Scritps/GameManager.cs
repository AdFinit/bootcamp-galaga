// Gives access to List
using System.Collections.Generic;
// Gives access to Unity's types like MonoBehaviour
using UnityEngine;

// ": MonoBehaviour" makes this a Unity component that can sit on a GameObject
public class GameManager : MonoBehaviour
{
    // static: one Instance for the whole game, reached as GameManager.Instance
    // get: any script can read it; private set: only GameManager can set it
    public static GameManager Instance { get; private set; }

    // The player's ship in the scene
    [SerializeField] private Player player;
    // Every enemy still alive; a List so destroyed enemies can be removed
    [SerializeField] private List<Enemy> enemies;
    // Seconds between enemy dives
    [SerializeField] private float diveInterval = 3f;

    // Runs before any Start, so Instance is ready for every other script
    private void Awake()
    {
        // This object is the one GameManager
        Instance = this;
    }

    // Runs once, when the scene starts
    private void Start()
    {
        // Every game starts with a score of 0
        Score.ResetPoints();
        // Send a random enemy diving every diveInterval seconds, starting after one interval
        InvokeRepeating(nameof(SendRandomDiver), diveInterval, diveInterval);
    }

    // Picks one living enemy and starts its dive
    private void SendRandomDiver()
    {
        // No enemies left: nothing to send
        if (enemies.Count == 0)
        {
            return;
        }

        // A random position in the list, from 0 up to Count - 1
        int index = Random.Range(0, enemies.Count);
        // That enemy starts diving
        enemies[index].StartDive();
    }

    // Called by an enemy as it dies, so it is never picked to dive again
    public void EnemyDestroyed(Enemy enemy)
    {
        // Take it out of the list
        enemies.Remove(enemy);
    }
}