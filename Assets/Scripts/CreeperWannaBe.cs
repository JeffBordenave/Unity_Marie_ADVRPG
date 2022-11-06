using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperWannaBe : Enemy
{
    override protected void Update()
    {
        base.Update();

        if (!TargetInRange(activeRange)) return;

        LookAtTarget();
        MoveForward();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerBeaconInstance.GetHurt(1);
            Destroy(gameObject);
        }
            
    }
}
