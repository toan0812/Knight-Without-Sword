using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Player movement;
    private Animator animator;
    private float lockedTill;
    #region Cached Properties

    private int currentState;

    private static readonly int Move = Animator.StringToHash("Run");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Hit = Animator.StringToHash("hit");
    #endregion
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<Player>();
    }
    void Update()
    {
        var state = GetState();
        if (state == currentState)
        {
            return;
        }
        animator.CrossFade(state, 0, 0);
        currentState = state;
    }

    private int GetState()
    {
        if (Time.time < lockedTill) return currentState;

        // Priorities
        //if (droneShooting.ISShooting() && !droneMovement.CanMove()) return LockState(CarGunShoot, 0.3f);
        //if (detectionTarget && !droneMovement.CanMove()) return CarGunUp;
        if (movement.IsRunning()) return Move;
        if (movement.Isidle()) return Idle;
        //if (droneMovement.Grounded() && droneMovement.CanMove()) return CarRun;
        return 0;

        int LockState(int s, float t)
        {
            lockedTill = Time.time + t;
            return s;
        }
    }
}
