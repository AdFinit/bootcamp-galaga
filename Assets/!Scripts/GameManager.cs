// Gives access to List
using System;
using System.Collections.Generic;
using System.Collections;
using Unity.Tutorials.Editor;

// Gives access to Unity's types like MonoBehaviour
using UnityEngine;
using Unity.VisualScripting;

// ": MonoBehaviour" makes this a Unity component that can sit on a GameObject
public class GameManager : MonoBehaviour
{
    // static: one Instance for the whole game, reached as GameManager.Instance
    // get: any script can read it; private set: only GameManager can set it
    public static GameManager Instance { get; private set; }

    // The player's ship in the scene
    [SerializeField] private Player player;
    // Every enemy still alive; a List so destroyed enemies can be removed
    private List<Enemy> enemies = new List<Enemy>();
    // Seconds between enemy dives
    [SerializeField] private float diveInterval = 3f;
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnDelay = 0.2f;
    private int wave = 0;

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
        StartCoroutine(WaveLoop());
    }

    private IEnumerator WaveLoop()
    {
        while (true)
        {
            wave++;
            Debug.Log("Wave " + wave);
            yield return StartCoroutine(SpawnWave());
            yield return new WaitForSeconds(diveInterval);

            while(enemies.Count > 0)
            {
                SendRandomDiver();
                yield return new WaitForSeconds(diveInterval);
            }
        }
    }

    private IEnumerator SpawnWave()
    {
        foreach (Transform spawn in spawnPoints)
        {
            SpawnEnemy(spawn);
            yield return new WaitForSeconds(spawnDelay);
        }
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
        int index = UnityEngine.Random.Range(0, enemies.Count);
        // That enemy starts diving
        enemies[index].StartDive();
    }

    // Called by an enemy as it dies, so it is never picked to dive again
    public void EnemyDestroyed(Enemy enemy)
    {
        // Take it out of the list
        enemies.Remove(enemy);
    }

    private void SpawnEnemy(Transform spawnPoint)
    {
        try
        {
            Enemy prefab = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];
            Enemy newEnemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            enemies.Add(newEnemy);
        }
        catch (Exception e)
        {
            Debug.LogError("Couldn't spawn enemy: " + e);
        }
        
    }

    public Player GetPlayer()
    {
        return player;
    }
    
}