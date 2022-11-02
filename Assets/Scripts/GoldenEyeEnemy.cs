using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GoldenEyeEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerTra;
    [SerializeField] private List<Transform> roamPos;

    public float speed = 3;
    public float bulletSpeed = 3;

    private int currentRoamPos = 0;
    private Vector3 targetRoam;

    private GameObject currentBullet = new GameObject();

    void Update()
    {
        transform.LookAt(GetPlayerPos());
        targetRoam = new Vector3(roamPos[currentRoamPos].position.x, 0, roamPos[currentRoamPos].position.z);
        transform.position += (targetRoam - transform.position) * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position,targetRoam) < 1)
        {
            if (currentRoamPos++ >= roamPos.Count - 1) currentRoamPos = 0;
            Shoot();
        }

        currentBullet.transform.position += currentBullet.transform.forward * bulletSpeed * Time.deltaTime;
    }

    Vector3 GetPlayerPos()
    {
        return playerTra.position;
    }

    void Shoot()
    {
        if (currentBullet != null) Destroy(currentBullet);
        currentBullet = CreateBullet();
    }

    GameObject CreateBullet()
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.localScale *= 0.5f;
        bullet.transform.rotation = transform.rotation;
        bullet.transform.localPosition = transform.position;
        bullet.tag = "Bullet";
        return bullet;
    }
}
