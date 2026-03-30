using UnityEngine;

public class EnemyHp : HpScript
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Debug.Log($"take {damage}damage");
        if (curHp == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("destroy");
        }
    }
    public override void Heal(float amount)
    {
        base.Heal(amount); 
    }
}