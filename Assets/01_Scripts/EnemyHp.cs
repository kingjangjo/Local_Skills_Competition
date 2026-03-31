using UnityEngine;

public class EnemyHp : HpScript
{
    public int dropMoney = 10;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Debug.Log($"take {damage}damage");
        if (curHp == 0)
        {
            MoneyManager.instance.AddMoney(10);
            Destroy(this.gameObject);
            Debug.Log("destroy");
        }
    }
    public override void Heal(float amount)
    {
        base.Heal(amount); 
    }
}