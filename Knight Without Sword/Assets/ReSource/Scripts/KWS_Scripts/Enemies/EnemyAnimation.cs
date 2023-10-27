using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private EnemyDamageReciver enemyDamageReciver;
    private Animator animator;
    //private static readonly int Move = Animator.StringToHash("run");
    //private static readonly int Idle = Animator.StringToHash("idle");
    //private static readonly int Hit = Animator.StringToHash("hit");
    private const string Hit = "hit";
    private const string Idle = "idle";
    private int currentState;
    private float lockedTill;
    private void Awake()
    {
        enemyDamageReciver = GetComponent<EnemyDamageReciver>();
    }
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    //void Update()
    //{
    //    //var state = GetState();
    //    //if (state == currentState)
    //    //{
    //    //    return;
    //    //}
    //    //animator.CrossFade(state, 0, 0);
    //    //currentState = state;

    //}
    void Update()
    {
        animator.SetBool(Idle, !enemyDamageReciver.DamageRecive());
        animator.SetBool(Hit, enemyDamageReciver.DamageRecive());
        //animator.SetBool(IS_JUMPING, PlayerManager.Instance.PlayerMovement.IsJumping());
        //animator.SetBool(IS_CROUCH, PlayerManager.Instance.PlayerMovement.IsCrouch());
    }
    private int GetState()
    {
        if (Time.time < lockedTill) return currentState;

        // Priorities
        //if (droneShooting.ISShooting() && !droneMovement.CanMove()) return LockState(CarGunShoot, 0.3f);
        //if (detectionTarget && !droneMovement.CanMove()) return CarGunUp;
        //if (enemyDamageReciver.DamageRecive()) return Hit;
        //else if (!enemyDamageReciver.DamageRecive()) return Idle;
        //if (movement.Isidle()) return Idle;
        //if (droneMovement.Grounded() && droneMovement.CanMove()) return CarRun;
        return 0;

        int LockState(int s, float t)
        {
            lockedTill = Time.time + t;
            return s;
        }
    }
}

