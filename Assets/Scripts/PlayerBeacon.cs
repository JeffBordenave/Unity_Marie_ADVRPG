using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBeacon : MonoBehaviour
{
    [SerializeField] private CapsuleCollider hurtBox;
    [SerializeField] private float maxHealth = 10;

    static public PlayerBeacon instance;

    private Animator animator;
    private float health;

    private void Awake()
    {
        instance = this;
        health = maxHealth;
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

    public void GetHurt()
    {
        print(health);
        health--;
        if (health < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
