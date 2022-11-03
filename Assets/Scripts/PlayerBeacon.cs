using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeacon : MonoBehaviour
{
    static public PlayerBeacon instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }
}
