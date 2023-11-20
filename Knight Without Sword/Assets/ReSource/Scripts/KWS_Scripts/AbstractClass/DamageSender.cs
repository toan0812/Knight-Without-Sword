using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : Enemy
{
    protected abstract int SendDamage(int damage);
}
