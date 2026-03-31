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
}