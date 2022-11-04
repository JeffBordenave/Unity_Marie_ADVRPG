using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarkSoulsEnemy : Enemy
{
    public UnityEvent playerInRangeEvent;
    public float hitRange = 4;

    void Start()
    {
        base.Start();
        if (playerInRangeEvent == null)
            playerInRangeEvent = new UnityEvent();
    }

    void Update()
    {
        if (!TargetInRange(activeRange)) return;

        LookAtTarget();

        if (TargetInRange(hitRange))
        {
            playerInRangeEvent?.Invoke();
        }
        else MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") playerBeaconInstance.GetHurt();
    }
}
