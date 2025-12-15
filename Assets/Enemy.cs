using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed = 2.0f;
    [SerializeField] protected string Name = "Enemy";
    [SerializeField] protected int Health = 100;


    protected void Update()
    {
        MoveAround();
        Attack();
    }

    protected void MoveAround()
    {
    }

    protected virtual void Attack()
    {
        // Placeholder for attack logic
        Debug.Log($"{Name} attacks!");
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{Name} took {damage} damage. Remaining health: {Health}");
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{Name} has died.");
        Destroy(gameObject);
    }
}
