using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<ItemType, int> items;

    private void Awake()
    {
        items = new Dictionary<ItemType, int>();
    }

    public void AddItem(Item item, int quantity = 1)
    {
        if (!items.ContainsKey(item.type))
        {
            items.Add(item.type, quantity);
        }
        else
        {
            items[item.type] += quantity;
        }
    }

    public void PrintInventory()
    {
        foreach (KeyValuePair<ItemType, int> entry in items)
        {
            Debug.Log($"{entry.Key}: {entry.Value}");
        }
    }
}
