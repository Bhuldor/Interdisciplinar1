using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInventory : MonoBehaviour
{
    private string ItemName = "Item teste";
    private int id = 0;
    public int quantity;
    public GameObject inventoryParent;
    public Font fontMessage;

    public delegate void DropObtain(Item item);
    public static event DropObtain OnDropObtain;



    public void AddTestItem()
    {
        Item test = new Item {
            name = ItemName + " " + id,
            id = this.id,
            quantity = this.quantity
        };
        id++;
        Inventory.instance.Add(test);
        OnDropObtain?.Invoke(test);
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
        
        int count = inventoryParent.transform.childCount;
        if(count != 0)
        {
            for (int a = 0; a < count; a++)
            {
                Destroy(inventoryParent.transform.GetChild(a).gameObject);
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
            itemText.transform.SetParent(inventoryParent.transform);
            LeanTween.scale(newItem, new Vector3(1, 1, 1), 0.1f);
        }
        LeanTween.scale(inventoryParent, new Vector3(1, 1, 1), 0.1f);
    }
}
