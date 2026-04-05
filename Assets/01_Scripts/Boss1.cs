using UnityEngine;

[RequireComponent(typeof(EnemyHp))]
[RequireComponent(typeof(Rigidbody))]
public class Boss1 : BossState
{
    public EnemyHp hp;
    public Rigidbody bossRb;
    public GameObject target;
    public float moveSpeed = 5f;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        hp = GetComponent<EnemyHp>();
        bossRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        bossRb.gameObject.transform.LookAt(target.transform);
        Vector3 distance = target.transform.position - gameObject.transform.position;
        if (distance.magnitude < 15f)
        {
            if (hp.curHp >= hp.maxHp * 0.5f)
                Attack1();
            else
                Attack2();
        }
        else
        {
            Move();
        }
    }
    public override void Idle()
    {
        base.Idle();
    }
    public override void Move()
    {
        bossRb.linearVelocity = moveSpeed * gameObject.transform.forward * Time.deltaTime;
        bossRb.linearVelocity = Vector3.Lerp(bossRb.linearVelocity, Vector3.zero, 0.15f);
    }
    public override void Attack1()
    {
        var shoot = GetComponent<Shootter>();
        if (shoot != null)
            return;
        shoot = this.gameObject.AddComponent<Shootter>();
        shoot.shootDelay = 0.1f;
        shoot.shootCount = 5;
        shoot.shootAutoCount = 1;
        shoot.spreadAngle = 90f;
        shoot.shootForce = 100f;
    }
    public override void Attack2()
    {
        this.gameObject.AddComponent<Shootter>();
    }
}