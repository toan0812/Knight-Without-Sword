using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPlatform : Platform
{
    private enum State { 
        Lock,Unlocked,Opening
    }
    private State state;
    private void Start()
    {
        state = State.Lock;
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
                //state = State.Opening;
                break;
            case State.Opening:
                state = State.Unlocked;
                break;
            case State.Unlocked:
                break;
            
        }    
    }
}
