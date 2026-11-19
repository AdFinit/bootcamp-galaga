using UnityEngine;

public class StatsReader : MonoBehaviour
{
    // Which stats asset to read; drag one in from the Project window
    [SerializeField] private EnemyStats stats;

    // Runs once when you press Play
    private void Start()
    {
        // Paint this square the colour from the asset
        GetComponent<SpriteRenderer>().color = stats.GetColor();
        // Print the rest of the stats
        Debug.Log(stats.Describe());
    }
}
