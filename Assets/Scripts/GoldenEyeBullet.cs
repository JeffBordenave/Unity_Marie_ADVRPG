using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenEyeBullet : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float lifeSpan;

    private float counter;

    private PlayerBeacon beacon;

    void Start()
    {
        counter = 0;
    }

    void Update()
    {
        if ((counter += Time.deltaTime) > lifeSpan) Destroy(gameObject);

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            print("touché");
            PlayerBeacon.instance.GetHurt();
        }


        Destroy(gameObject);
    }
}
