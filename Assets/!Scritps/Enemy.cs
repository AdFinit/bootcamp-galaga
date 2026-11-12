using UnityEngine;


public abstract class Enemy : Ship
{

    public enum EnemyState
    {
       
        Flying,
        
        Diving
    }

    [SerializeField] private int points = 100;
    private EnemyState state = EnemyState.Flying;

    // Runs every frame
    private void Update()
    {
        if (state == EnemyState.Diving)
        {
            DiveMove();
        }
    }


    public void StartDive()
    {

        state = EnemyState.Diving;

        Shoot();
    }


    protected virtual void DiveMove()
    {

        Move(Vector2.down);
    }

    
    public override void Shoot()
    {

        weapon.Shoot(transform.position, Vector2.down);
    }


    public override void Die()
    {
        // Static class: no object needed, just the class name
        Score.AddPoints(points);
        // Static Instance: reach the one GameManager without a reference slot
        GameManager.Instance.EnemyDestroyed(this);
        // base.Die() runs Ship's version, which destroys the GameObject
        base.Die();
    }
}