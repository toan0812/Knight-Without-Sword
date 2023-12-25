using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CloseRange : Enemy
{
    private enum State { idle, following,attack, dead }
    private State state;
    [SerializeField] private Animator animator;
    [SerializeField] private float  attackRange;
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
                if(TargetOnAttackZone(target,rangeFollowing))
                {
                    agent.isStopped = false;
                    state = State.following;
                }
                break;
            case State.following:
                EnemyMove();
                if (!TargetOnAttackZone(target, rangeFollowing))
                {
                    agent.isStopped = true;
                    state = State.idle;
                }
                //state = State.dead;
                break;
            case State.attack:
                {
                    if(TargetOnAttackZone(target, attackRange))
                    {
                        EnemyAttack();
                    }
                }
                break;   
            case State.dead:
                break;
        }

    }
    protected override void EnemyAttack()
    {
        animator.SetBool("attack", TargetOnAttackZone(target, attackRange));
    }

    public override void EnemyMove()
    {
        base.EnemyMove();
        animator.SetBool("run", TargetOnAttackZone(target, rangeFollowing));
    }
}
