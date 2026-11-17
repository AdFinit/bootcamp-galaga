using UnityEngine;
using System;

public static class Score
{
    //var used to store score for whole game ONLY one instance can exist 
    private static int points;
    public static event Action<int> onPointsChanged;

    //method to reset points called from game manager
    public static void ResetPoints()
    {
        points = 0;
        onPointsChanged?.Invoke(points);
    }

    //method to add points can be called in the following format Score.AddPoints(100);
    public static void AddPoints(int amount)
    {
        points += amount;
        Debug.Log("points added");
        onPointsChanged?.Invoke(points);
    }
}
