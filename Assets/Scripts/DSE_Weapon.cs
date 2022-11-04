using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSE_Weapon : MonoBehaviour
{
    public DarkSoulsEnemy dseScript;
    public CapsuleCollider hitCollider;
    private Animator anim;

    private void Start()
    {
        dseScript.playerInRangeEvent.AddListener(Hit);
        anim = GetComponent<Animator>();
    }

    private void Hit()
    {
        anim.Play("Enemy_3_Attack");
    }

    private void EnableHitbox()
    {
        hitCollider.enabled = true;
    }

    private void DisableHitBox()
    {
        hitCollider.enabled = false;
    }
}
