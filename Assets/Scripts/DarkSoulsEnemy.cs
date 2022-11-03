using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSoulsEnemy : Enemy
{
    float timeCount = 0.0f;

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
