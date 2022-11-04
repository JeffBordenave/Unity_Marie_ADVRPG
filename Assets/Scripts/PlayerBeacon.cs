using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBeacon : MonoBehaviour
{
    [SerializeField] private CapsuleCollider hurtBox;

    static public PlayerBeacon instance;
    private Animator animator;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("Player_Attack");
        }
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    public void EnableHitBox()
    {
        hurtBox.enabled = true;
    }

    public void DisableHitBox()
    {
        hurtBox.enabled = false;
    }
}
