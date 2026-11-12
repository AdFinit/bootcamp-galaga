// Gives access to Unity types
using UnityEngine;

// A Butterfly is an Enemy that dives its own way
public class Butterfly : Enemy
{
    
    [SerializeField] private float diveSpeedMult = 1.5f;
    // override replaces Enemy's dive with the Butterfly's own
    protected override void DiveMove()
    {
        // Dive down and to the right
        Move(new Vector2(1f, -1f), diveSpeedMult);
    }
}