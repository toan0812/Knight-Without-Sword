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
    private bool faceRight = true;
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
                    agent.isStopped = false;
                    state = State.following;
                }
                break;
            case State.following:
                EnemyMove();
                if (!TargetOnAttackZone(target, radiusZone))
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

    protected override void EnemyMove()
    {
        base.EnemyMove();
        Vector3 movedir = new Vector3(-transform.position.x + target.transform.position.x, -transform.position.y + +target.transform.position.y).normalized;
        animator.SetBool("run", TargetOnAttackZone(target, radiusZone));
        //animator.SetFloat("back", movedir.x);
        if (faceRight && movedir.x < 0)
        {
            FaceFlip();
            faceRight = false;
        }
        if (!faceRight && movedir.x > 0)
        {
            FaceFlip();
            faceRight = true;
        };
    }

    private void FaceFlip()
    {
        Vector3 Scaler = transform.GetChild(0).localScale;
        Scaler.x = Scaler.x * -1;
        transform.GetChild(0).localScale = Scaler;
    }
}
