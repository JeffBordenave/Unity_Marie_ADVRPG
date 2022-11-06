using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerBeacon playerBeaconInstance;
    private Animator animator;
    public float activeRange = 25;
    public float moveSpeed = 10;
    public float rotationSpeed = 10;
    public float xpGain = 3;

    protected void Start()
    {
        tag = "Enemy";
        playerBeaconInstance = PlayerBeacon.instance;
        animator = GetComponent<Animator>();
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
        animator.Play("Enemy_Death");
    }

    public void DeathAnimOver()
    {
        Destroy(gameObject);
        playerBeaconInstance.GetXP(xpGain);
    }
}