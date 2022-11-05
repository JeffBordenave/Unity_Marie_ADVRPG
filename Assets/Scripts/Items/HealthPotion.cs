using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{

    public float healthGiven;

    public override void Use()
    {
        base.Use();
        FindObjectOfType<PlayerBeacon>().GetHurt(-healthGiven);
    }

}
