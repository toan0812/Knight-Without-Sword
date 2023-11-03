using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlatform : Platform
{
    [SerializeField] private bool checkOpeningConditions;
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    public enum State { 
        Lock,Unlocked,Opening
    }
    public State state;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        PlatformState();
    }
    protected override void PlatformState()
    {
        switch(state)
        {
            case State.Lock:
                if(checkOpeningConditions)
                {
                    state = State.Opening;
                }
                break;
            case State.Opening:
                animator.SetBool("Opening", true);
                state = State.Unlocked;
                break;
            case State.Unlocked:
                boxCollider2D.isTrigger = true;
                break;
            
        }    
    }
}
