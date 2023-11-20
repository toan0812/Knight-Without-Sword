using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHoder : MonoBehaviour
{
    public CharactersAbility charactersAbility;
    float cooldownTime;
    float activeTime;

    enum AbilityState { ready, active, cooldown}
    AbilityState state = AbilityState.ready;
    [SerializeField] private KeyCode key;
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    charactersAbility.Activate();
                    state = AbilityState.active;
                    activeTime = charactersAbility.activeTime;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    charactersAbility.BeginCoolDown();
                    cooldownTime = charactersAbility.cooldownTime;
                    state = AbilityState.cooldown;
                   
                }
                break;
            case AbilityState.cooldown:
                if(cooldownTime>0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    
                    state = AbilityState.ready;
                }
                break;
        }

        
    }


}
