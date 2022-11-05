using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public virtual void Use()
    {
        print("Item " + this.name + " has been used");
    }
}
