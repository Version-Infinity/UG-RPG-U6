using UnityEngine;

public class Enemy_Goblin : Enemy
{

    protected override void Attack()
    {
        SteelMoney();
    }

    private void SteelMoney()
    {
        Debug.Log($"{Name} steals money from the player!");
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Debug.Log($"{Name} the Goblin snarls in pain!");
    }
}
