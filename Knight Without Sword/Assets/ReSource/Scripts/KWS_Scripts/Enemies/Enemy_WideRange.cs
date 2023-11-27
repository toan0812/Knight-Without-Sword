using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WideRange : Enemy
{
    private enum State { idle,attacking, run, dead }
    
    [Header("Range Attack")]
    [SerializeField] private float rangeAttack;
    [SerializeField] private LayerMask wallLayer;

    [Header("Point to Spawn Bullet")]
    [SerializeField] protected Transform shootingPoint;
    [SerializeField] private Transform holder;
    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int amount;
    List<GameObject> bulletTapes = new List<GameObject>();

    [Header("Time To Delay BTW Shoot")]
    [SerializeField] private float timeDelayMax;
    private float timeDelay;

    private bool canMove = false;
    private bool canAttack = false;
    private bool isidle = false;
    private bool faceRight = true;
    private State state = State.idle;
    protected override void Start()
    {
        base.Start();
        PoolingObject.Instance.addPool(bulletPrefab.GetComponentInChildren<Bullet>().gameObject, bulletTapes, amount, holder);
        timeDelay = timeDelayMax;

    }
    void Update()
    {
        switch (state)
        {
            case State.idle:
                if (TargetOnAttackZone(target, rangeAttack))
                {
                    state = State.attacking;
                }
                break;
            case State.attacking:
                EnemyAttack();  
                if (!TargetOnAttackZone(target, rangeAttack))
                {
                    canMove = true;
                    state = State.run;
                     
                }
                break;
             case State.run:
                if(canMove)
                {
                    agent.isStopped = false;
                    isidle = false;
                    Vector3 vector2 = target.position - transform.position.normalized;
                    agent.SetDestination(target.position - transform.position.normalized);
                }
                if (TargetOnAttackZone(target, rangeAttack))
                {
                    agent.isStopped = true;
                    canMove = false;
                    state = State.attacking;
                }
                break;
            case State.dead:
                break;
        }
        Vector3 movedir = new Vector3(-transform.position.x + target.transform.position.x, -transform.position.y + +target.transform.position.y).normalized;
        //Flip
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

    protected override void EnemyAttack()
    {
        canMove = false;
        timeDelay -= Time.deltaTime;
        canAttack = timeDelay <= 0.25f;
        if (timeDelay <= 0)
        {
            GameObject Bullet = PoolingObject.Instance.GetPoolingobj(bulletTapes);
            Bullet.transform.position = shootingPoint.position;
            
            Bullet.SetActive(true);
            timeDelay = timeDelayMax;
            
        }
        if(!canAttack)
        {
            isidle = true;
        }
        else isidle = false;
    }

    private void FaceFlip()
    {
        Vector3 Scaler = transform.GetChild(0).localScale;
        Scaler.x = Scaler.x * -1;
        transform.GetChild(0).localScale = Scaler;
    }
    public bool IsIdle()
    {
        return isidle;
    }    
    public bool IsRun()
    {
        return state == State.run;
    } 
    public bool IsAttack()
    {
        return canAttack;
    }
}
