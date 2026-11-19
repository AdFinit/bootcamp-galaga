using TMPro;
using Unity.Tutorials.Editor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Player _player;
    
    void Start()
    {
        _player.GetHealth().OnHealthChanged += updateHealth;
        updateHealth(_player.GetHealth().GetCurrentHealth());
    }

    private void OnEnable()
    {
        Score.onPointsChanged += UpdateScore;
    }

    private void OnDisable()
    {
        Score.onPointsChanged -= UpdateScore;
    }

    private void UpdateScore(int points)
    {
        scoreText.text = "Score: " + points;
    }

    private void updateHealth(int health)
    {
        healthText.text = "Health: " + health;
    }
}
