using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CloseRange : Enemy
{
    private enum State { idle, following, dead }
    private State state;
    [SerializeField] private Animator animator;
    [Header("Attack Zone Radius")]
    [SerializeField] private float radiusZone;
    protected override void Start()
    {
        base.Start();
        state = State.idle;
    }
    
    void Update()
    {
        switch (state)
        {
            case State.idle:
                if(TargetOnAttackZone(target,radiusZone))
                {
                    state = State.following;
                }
                break;
            case State.following:
                EnemyMove();
                if (!TargetOnAttackZone(target, radiusZone))
                {
                    state = State.idle;
                }
                //state = State.dead;
                break;
            case State.dead:
                break;
        }

    }

    protected override void EnemyMove()
    {
        base.EnemyMove();
        Vector3 movedir = new Vector3(-transform.position.x + target.transform.position.x, -transform.position.y + +target.transform.position.y).normalized;
        animator.SetFloat("front", movedir.y);
        animator.SetFloat("back", movedir.x);
    }
}
