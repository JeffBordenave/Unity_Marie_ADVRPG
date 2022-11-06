using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerBeacon playerBeaconInstance;
    public float activeRange = 25;
    public float moveSpeed = 10;
    public float rotationSpeed = 10;
    public float xpGain = 3;

    private bool hasToDie = false;
    private float counter = 0;

    virtual protected void Start()
    {
        tag = "Enemy";
        playerBeaconInstance = PlayerBeacon.instance;
    }

    virtual protected void Update()
    {
        if(hasToDie) DeathAnimation();
    }

    public bool TargetInRange(float range)
    {
        return Vector3.Distance(playerBeaconInstance.GetTransform().position, transform.position) < range;
    }

    public void MoveForward()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void LookAtTarget()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, playerBeaconInstance.transform.rotation, rotationSpeed * Time.deltaTime);
        transform.LookAt(playerBeaconInstance.transform.position);
    }

    public void Die()
    {
        hasToDie = true;
    }

    private void DeathAnimation()
    {
        transform.localScale /= 1.1f;
        if ((counter += Time.deltaTime) > 1) DeathAnimOver();
    }

    public void DeathAnimOver()
    {
        Destroy(gameObject);
        playerBeaconInstance.GetXP(xpGain);
    }
}