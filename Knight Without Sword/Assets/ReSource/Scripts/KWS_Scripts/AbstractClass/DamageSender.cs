using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class DamageSender : Enemy
{
    protected abstract int SendDamage(int damage);
}
