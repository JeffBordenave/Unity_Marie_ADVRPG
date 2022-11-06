using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBeacon : MonoBehaviour
{
    [SerializeField] private CapsuleCollider hurtBox;

    static public PlayerBeacon instance;
    [Space]
    public HealthBar healthBar = default;
    public float maxHealth = 20;
    public float healthGainOnLvlUp = 2;
    [Space]
    public HealthBar XPBar = default;
    public float maxXp = 20;
    [Space]
    public Inventory inv = default;
    [Space]
    public float speedBoostTime = 2;

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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inv.UseItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inv.UseItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inv.UseItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inv.UseItem(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            inv.UseItem(4);
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

    public void FindItem(Item item)
    {
        inv.AddItem(item);
    }

    public void IncreaseSpeed()
    {
        StartCoroutine(SpeedCoroutine());
    }

    public IEnumerator SpeedCoroutine()
    {
        GetComponent<FirstPersonController>().MoveSpeed *= 3f;
        GetComponent<FirstPersonController>().SprintSpeed *= 3f;
        yield return new WaitForSeconds(speedBoostTime);
        GetComponent<FirstPersonController>().MoveSpeed /= 3f;
        GetComponent<FirstPersonController>().SprintSpeed /= 3f;
    }
}