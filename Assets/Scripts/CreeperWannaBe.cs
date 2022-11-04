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
        if (!TargetInRange(activeRange)) return;

        LookAtTarget();
        MoveForward();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerBeaconInstance.GetHurt();
            Destroy(gameObject);
        }
            
    }
}
