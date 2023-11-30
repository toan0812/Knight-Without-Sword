using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CloseRange : Enemy
{
    private enum State { idle, following, dead }
    private State state;
    [SerializeField] private Animator animator;
    protected override void Start()
    {
        base.Start();
        state = State.idle;
    }
    
    void Update()
    {
        LookAtTarget();
        switch (state)
        {
            case State.idle:
                if(TargetOnAttackZone(target,rangeAttack))
                {
                    agent.isStopped = false;
                    state = State.following;
                }
                break;
            case State.following:
                EnemyMove();
                if (!TargetOnAttackZone(target, rangeAttack))
                {
                    agent.isStopped = true;
                    state = State.idle;
                }
                //state = State.dead;
                break;
            case State.dead:
                break;
        }

    }

    public override void EnemyMove()
    {
        base.EnemyMove();
        animator.SetBool("run", TargetOnAttackZone(target, rangeAttack));
    }
}
