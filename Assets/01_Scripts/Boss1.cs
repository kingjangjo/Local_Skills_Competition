using UnityEngine;

[RequireComponent(typeof(EnemyHp))]
public class Boss1 : BossState
{
    public EnemyHp hp;
    private void Start()
    {
        hp = GetComponent<EnemyHp>();
    }
    private void Update()
    {

    }
}