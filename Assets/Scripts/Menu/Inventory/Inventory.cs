using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    public void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Mais de uma instancia de inventario.");
        }
        instance = this;
    }

    #endregion 

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        if (items.Contains(item))
        {
            items[items.IndexOf(item)].quantity += item.quantity;
        }
        else{
            items.Add(item);
        }
    }

    public void Remove(Item item)
    {
        items[items.IndexOf(item)].quantity -= item.quantity;

        if (items[items.IndexOf(item)].quantity == 0)
        {
            items.Remove(item);
        }

    }
}
