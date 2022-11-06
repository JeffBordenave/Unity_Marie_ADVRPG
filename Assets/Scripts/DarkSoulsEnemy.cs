using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarkSoulsEnemy : Enemy
{
    public UnityEvent playerInRangeEvent;
    public float hitRange = 4;

    override protected void Start()
    {
        base.Start();

        if (playerInRangeEvent == null)
            playerInRangeEvent = new UnityEvent();
    }

    override protected void Update()
    {
        base.Update();

        if (!TargetInRange(activeRange)) return;

        LookAtTarget();

        transform.LookAt(playerBeaconInstance.transform.position);

        if (TargetInRange(hitRange))
        {
            playerInRangeEvent?.Invoke();
        }
        else MoveForward();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") playerBeaconInstance.GetHurt(3);
    }
}
