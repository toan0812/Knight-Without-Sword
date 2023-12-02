using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Boss_1Animation : MonoBehaviour
{

    [SerializeField] Boss_1Controller controller;
    [SerializeField] Boss_1ShootAction shootAction;
    private Animator animator;
    private float lockedTill;
    private List<int> stateInts = new List<int>();
    int number = 0;
    [Header("Time Delay Animation")]
    [SerializeField] private float timeDelayMax;
    private float timeDelay;
    // Time for endActive Lazer
    #region Cached Properties

    private int currentState;

    private static readonly int Run = Animator.StringToHash("run");
    private static readonly int Idle = Animator.StringToHash("idle");
    private static readonly int Hit = Animator.StringToHash("hit");
    private static readonly int Attack1 = Animator.StringToHash("Attack_1");
    private static readonly int Attack_2 = Animator.StringToHash("Attack_2");
    private static readonly int Attack_3 = Animator.StringToHash("Attack_3");
    #endregion
    void Start()
    {
        stateInts.Add(Idle);
        stateInts.Add(Run);  
        stateInts.Add(Attack1);
        stateInts.Add(Attack_2);
        stateInts.Add(Attack_3);
        animator = GetComponent<Animator>();
        timeDelay = timeDelayMax;
    }

    //void Update()
    //{
    //    GetRandomStateInts();
    //    var state = GetState();
    //    if (state == currentState)
    //    {
    //        return;
    //    }
    //    animator.CrossFade(state, 0, 0);
    //    currentState = state;

    //}
    private void Update()
    {
        if (number == 4)
        {
            StartCoroutine(ShootForAttack3());
        }
        GetRandomStateInts();
        var state = GetState();
        if (state == currentState)
        {
            return;
        }

        animator.CrossFade(state, 0, 0);
        currentState = state;

      
    }
    private void FixedUpdate()
    {
       
    }

    private int GetState()
    {
        if (Time.time < lockedTill) return currentState;

        // Priorities
        switch (number)
        { 
            case 0:
                GetRandomStateInts();
                break;
            case 1:
                return LockState(stateInts[1],0.25f);
            case 2:
                return LockState(stateInts[2], 0.25f);
            case 3:
                return LockState(stateInts[3], 0.25f);
            case 4:
                return LockState(stateInts[4], 0.25f);
        
        }
        
        return 0;

        int LockState(int s, float t)
        {
            lockedTill = Time.time + t;
            return s;
        }
    }

    void GetRandomStateInts()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay <= 0)
        {
            number = Random.Range(0, stateInts.Count);
            timeDelay = timeDelayMax;
        }
    }





    /// <summary>
    /// This func only uses for reference func shooting at shootAction func, Besides nothing :))
    /// </summary>
    public void ShootForAttack1()
    {
        shootAction.Attack_1Shooting();
    } 
    public void ShootForAttack2()
    {
        shootAction.Attack_2Shooting();
    } 
    IEnumerator ShootForAttack3()
    {
        yield return new WaitForSeconds(.5f);
        StartAttack3Pos();
        yield return new WaitForSeconds(2f);
        shootAction.Attack_3Shooting();
        yield return new WaitForSeconds(.5f);
        shootAction.EndActiveLazer();
        
   
    } 


    public void StartAttack3Pos()
    {
        shootAction.SetActiveSpawnPos();
    }
}
