using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerBeacon playerBeaconInstance;
    public float activeRange = 25;
    public float moveSpeed = 10;
    public float rotationSpeed = 10;


    protected void Start()
    {
        playerBeaconInstance = PlayerBeacon.instance;
    }

    public bool TargetInRange(float range)
    {
        return Vector3.Distance(playerBeaconInstance.GetTransform().position, transform.position) < range;
    }

    public void MoveForward()
    {
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }

    public void LookAtTarget()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, playerBeaconInstance.transform.rotation, rotationSpeed * Time.deltaTime);
        transform.LookAt(playerBeaconInstance.transform.position);
    }
}