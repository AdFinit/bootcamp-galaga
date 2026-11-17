using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    
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
}
