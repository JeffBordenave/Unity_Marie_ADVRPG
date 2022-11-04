using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredAreaTrigger : MonoBehaviour
{
    bool hasBeenActivated;
    public string areaName;

    private void Awake()
    {
        hasBeenActivated = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenActivated && other.gameObject.CompareTag("Player"))
        {
            hasBeenActivated = true;
            DiscoveryPopUp.EnteredNewArea.Invoke(areaName);
        }
    }
}
