using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    public List<Image> slots;
    public int maxItems = 5;

    public void AddItem(Item item)
    {
        if (items.Count >= maxItems)
        {
            print("l'inventaire est plein !");
            return;
        }
        Item myItem = Instantiate(item, slots[items.Count].transform);
        print(myItem);
        myItem.GetComponent<Image>().enabled = true;
        items.Add(myItem);
        print(items.Count);
    }

    public void UseItem(int index)
    {
        if (index >= items.Count) return;
        
        items[index].Use();
        Destroy(items[index].gameObject);
        items.RemoveAt(index);

        Actualize();
    }

    public void Actualize()
    {
        Item[] l = new Item[items.Count];
        items.CopyTo(l);
        items.Clear();

        for (int i = 0; i < maxItems; i++)
        {
            if (slots[i].GetComponentInChildren<Item>() != null) Destroy(slots[i].GetComponentInChildren<Item>().gameObject);

            if (i < l.Length) AddItem(l[i]);
        }
    }
}