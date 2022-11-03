using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GoldenEyeEnemy : MonoBehaviour
{
    [SerializeField] private GoldenEyeBullet bullet;

    public GameObject gun;
    public Transform gunTip;
    public Transform bulletTargetTra;
    public List<Transform> roamPos;
    public float speed = 3;
    public float bulletSpeed = 3;
    public float minDistanceToLookAtPlayer = 20;

    private int currentRoamPos = 0;
    private Vector3 targetRoam;
    private GameObject currentBullet = null;

    void Update()
    {
        if(!IsPlayerClose()) return;
            
        transform.LookAt(GetTargetPos());
        targetRoam = new Vector3(roamPos[currentRoamPos].position.x, 0, roamPos[currentRoamPos].position.z);
        transform.position += (targetRoam - transform.position) * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position,targetRoam) < 1)
        {
            if (currentRoamPos++ >= roamPos.Count - 1) currentRoamPos = 0;
            Shoot();
        }

        currentBullet.transform.position += currentBullet.transform.forward * bulletSpeed * Time.deltaTime;

        gun.transform.LookAt(bulletTargetTra.position);
    }

    Vector3 GetTargetPos()
    {
        return bulletTargetTra.position;
    }

    bool IsPlayerClose()
    {
        return Vector3.Distance(GetTargetPos(), transform.position) < minDistanceToLookAtPlayer;
    }

    void Shoot()
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.localScale *= 0.2f;
        bullet.transform.rotation = gun.transform.rotation;
        bullet.transform.localPosition = gunTip.position;
        bullet.tag = "Bullet";
    }
}
