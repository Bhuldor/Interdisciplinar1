using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    public string ItemName;
    public int id;
    public int quantity;

    public void AddTestItem()
    {
        Item test = new Item {
            name = ItemName,
            id = this.id,
            quantity = this.quantity
        };

        Inventory.instance.Add(test);
    }

    public void RemoveTestItem()
    {
        Item test = new Item
        {
            id = this.id,
            quantity = this.quantity
        };

        Inventory.instance.Remove(test);
    }

    public void ListInventory()
    {
        foreach (Item i in Inventory.instance.items)
        {
            Debug.Log($"id: {i.id} name: {i.name} quantity: {i.quantity}");
        }
    }
}
