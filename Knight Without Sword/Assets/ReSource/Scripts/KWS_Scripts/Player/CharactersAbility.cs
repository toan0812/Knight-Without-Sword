using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersAbility : ScriptableObject
{
    public new string nameAbility;
    public float cooldownTime;
    public float activeTime;
    public virtual void Activate() { } 
    public virtual void BeginCoolDown() { }
}
