using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSoulsEnemy : Enemy
{
    [SerializeField] private Transform playerTra;
    public float rotateSpeed = 10;

    float speed = 1f;
    float timeCount = 0.0f;

    private void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (!TargetInRange()) return;

        transform.rotation = Quaternion.Lerp(transform.rotation, playerTra.rotation, rotateSpeed * Time.deltaTime);
        transform.position -= transform.forward * speed * Time.deltaTime;
    }
}
