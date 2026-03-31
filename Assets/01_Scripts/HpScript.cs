using UnityEngine;

public class HpScript : MonoBehaviour
{
    internal float curHp;
    public float maxHp;
    private void Start()
    {
        curHp = maxHp;
    }
    public virtual void TakeDamage(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            curHp = 0;
        }
    }
    public virtual void Heal(float amount)
    {
        curHp += amount;
        if (amount >= maxHp)
        {
            curHp = maxHp;
        }
    }
}