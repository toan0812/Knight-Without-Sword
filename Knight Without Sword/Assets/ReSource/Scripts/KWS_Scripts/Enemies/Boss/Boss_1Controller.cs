using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1Controller : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        LookAtTarget();
    }
}
