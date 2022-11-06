using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GoldenEyeEnemy : Enemy
{
    [SerializeField] private GoldenEyeBullet bullet;

    public GameObject gun;
    public Transform gunTip;
    public List<Transform> roamPos;
    public float bulletSpeed = 3;

    private int currentRoamPos = 0;
    private Vector3 targetRoam;

    override protected void Update()
    {
        base.Update();

        if(!TargetInRange(activeRange)) return;

        Move();

        if (Vector3.Distance(transform.position,targetRoam) < 1)
        {
            if (currentRoamPos++ >= roamPos.Count - 1) currentRoamPos = 0;
            Shoot();
        }
    }

    private void Move()
    {
        transform.LookAt(GetTargetPos());
        //targetRoam = new Vector3(roamPos[currentRoamPos].position.x, 0, roamPos[currentRoamPos].position.z);
        targetRoam = roamPos[currentRoamPos].position;
        transform.position += (targetRoam - transform.position) * moveSpeed * Time.deltaTime;
        gun.transform.LookAt(playerBeaconInstance.transform.position);
    }

    Vector3 GetTargetPos()
    {
        return playerBeaconInstance.transform.position;
    }

    void Shoot()
    {
        GoldenEyeBullet _bullet = Instantiate(bullet);
        _bullet.transform.rotation = gun.transform.rotation;
        _bullet.transform.localPosition = gunTip.position;
        _bullet.speed = bulletSpeed;
        _bullet.lifeSpan = 3;
        _bullet.target = playerBeaconInstance.transform;
    }
}
