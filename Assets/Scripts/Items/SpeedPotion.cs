using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : Item
{
    public float expGiven;

    public override void Use()
    {
        base.Use();
        FindObjectOfType<PlayerBeacon>().IncreaseSpeed() ;
    }
}
