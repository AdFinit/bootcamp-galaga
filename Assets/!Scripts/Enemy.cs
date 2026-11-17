using Unity.Tutorials.Editor;
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
    [SerializeField] private float attackRange = 4f;
    private Vector2 diveDirection = Vector2.down;
    private bool hasFired = false;

    // Runs every frame
    private void Update()
    {
        if (state == EnemyState.Diving)
        {
            DiveMove();
            if (!hasFired && isPlayerClose())
            {
                Shoot();
                hasFired = true;
            }
        }
        if (transform.position.y < -6f)
        {
            GameManager.Instance.EnemyDestroyed(this);
            Destroy(gameObject);
        }
    }


    public void StartDive()
    {
        state = EnemyState.Diving;
        diveDirection = directionToPlayer();
        Shoot();
    }

    protected Vector2 directionToPlayer()
    {
        Player player = GameManager.Instance.GetPlayer();
        if (player == null)
        {
            return Vector2.down;
        }
        return (player.transform.position - transform.position).normalized;
    }

    protected bool isPlayerClose()
    {
        Player player = GameManager.Instance.GetPlayer();
        if (player == null)
        {
            return false;
        }
        return Vector2.Distance(transform.position, player.transform.position) < attackRange;
    }

    protected virtual void DiveMove()
    {
        Move(diveDirection);
    }

    
    public override void Shoot()
    {
        weapon.Shoot(transform.position, directionToPlayer());
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