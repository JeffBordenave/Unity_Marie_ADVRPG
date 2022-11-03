using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerBeacon playerBeaconInstance;
    public float activeRange = 25;
    // Start is called before the first frame update
    protected void Start()
    {
        playerBeaconInstance = PlayerBeacon.instance;
    }

    public bool TargetInRange()
    {
        return Vector3.Distance(playerBeaconInstance.GetTransform().position, transform.position) < activeRange;
    }
}
