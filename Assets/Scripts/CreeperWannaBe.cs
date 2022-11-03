using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperWannaBe : Enemy
{
    [SerializeField] private Transform playerTra;

    public float speed = 10;

    void Start()
    {
        base.Start();
    }

        void Update()
    {
        transform.LookAt(GetPlayerPos());

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    Vector3 GetPlayerPos()
    {
        return playerTra.position;
    }
}
