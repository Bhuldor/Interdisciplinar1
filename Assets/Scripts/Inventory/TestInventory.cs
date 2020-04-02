using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInventory : MonoBehaviour
{
    public string ItemName;
    public int id;
    public int quantity;
    public Transform inventoryParent;
    public Font fontMessage;

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
        int count = inventoryParent.childCount;
        if(count != 0)
        {
            for (int a = 0; a < count; a++)
            {
                Destroy(inventoryParent.GetChild(a).gameObject);
            }
        }
        
        foreach (Item i in Inventory.instance.items)
        {
            GameObject newItem = new GameObject(i.name);
            var itemText = newItem.AddComponent<Text>();
            newItem.AddComponent<CanvasRenderer>();

            itemText.text = $"{i.name} x{i.quantity}";
            itemText.font = fontMessage;
            itemText.color = Color.black;
            itemText.rectTransform.sizeDelta = new Vector2(100, 35);
            itemText.transform.SetParent(inventoryParent);
        }
    }
}
