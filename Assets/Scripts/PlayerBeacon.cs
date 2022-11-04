using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBeacon : MonoBehaviour
{
    [SerializeField] private CapsuleCollider hurtBox;

    static public PlayerBeacon instance;

    public HealthBar healthBar = default;
    public float maxHealth = 20;
    public float healthGainOnLvlUp = 2;
    
    public HealthBar XPBar = default;
    public float maxXp = 20;

    private Animator animator;
    private float health;
    private float xp;

    private void Awake()
    {
        instance = this;
        health = maxHealth;
        xp = 0;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.SetMaxValue(maxHealth);
        healthBar.SetValue(maxHealth);
        XPBar.SetMaxValue(maxXp);
        XPBar.SetValue(0);
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

    public void GetHurt(float damage)
    {
        print(health);

        health-= damage;
        healthBar.SetValue(health);

        if (health < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetXP(float xpGain)
    {
        xp += xpGain;

        if (xp >= maxXp)
        {
            LevelUp();
            xp -= maxXp;
        }

        XPBar.SetValue(xp);
    }

    private void LevelUp()
    {
        maxHealth += healthGainOnLvlUp;
        health += healthGainOnLvlUp;

        healthBar.SetMaxValue(maxHealth);
        healthBar.SetValue(health);
    }
}
