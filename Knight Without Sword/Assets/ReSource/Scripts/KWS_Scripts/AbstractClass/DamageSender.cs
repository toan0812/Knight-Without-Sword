using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class DamageSender : Enemy
{
    [SerializeField] protected int damage;
    protected abstract int SendDamage(int damage);
}
