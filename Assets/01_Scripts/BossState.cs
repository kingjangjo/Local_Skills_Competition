using UnityEngine;

public class BossState : MonoBehaviour
{
    private enum State
    {
        Idle,
        Attack1,
        Attack2,
        Attack3,
        Move
    }
    private State currentState;
    void Start()
    {
        currentState = State.Idle;
    }
    private void Update()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Attack1:
                break;
            case State.Attack2:
                break;
            case State.Attack3:
                break;
            case State.Move:
                break;
        }
    }
    public virtual void Idle() { }
    public virtual void Attack1() { }
    public virtual void Attack2() { }
    public virtual void Attack3() { }
    public virtual void Move() { }
}