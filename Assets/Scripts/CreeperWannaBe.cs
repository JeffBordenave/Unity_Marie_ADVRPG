using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperWannaBe : Enemy
{
    void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (!TargetInRange()) return;

        LookAtTarget();
        MoveForward();
    }
}
