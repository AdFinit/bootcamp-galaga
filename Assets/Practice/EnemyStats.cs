using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Scriptable Objects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private string enemyName = "Enemy";
    [SerializeField] private int health = 10;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private int points = 100;
    [SerializeField] private Color color = Color.white;

    public Color GetColor()
    {
        return color;
    }

    public string Describe()
    {
        return enemyName + ": " + health + "health, speed " + moveSpeed + ", worth " + points + " points.";
    }
}
