using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Inventory
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();

    public delegate void DropObtain(Item item);
    public static event DropObtain OnDropObtain;

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
    }

    public int GetQuantity(Item item)
    {
        int index = items.IndexOf(item);
        return items[index].quantity;
    }

    public void ObtainDrop(Item item)
    {
        OnDropObtain?.Invoke(item);
        Add(item);
    }

    public Item GetItemByID(int id)
    {
        return items[id - 1];
    }

    public void CreateJson(string path)
    {
        string json = JsonUtility.ToJson(instance);
        File.WriteAllText(path, json);
    }

    public void ReadJson(string json)
    {
        instance = JsonUtility.FromJson<Inventory>(json);
    }
}
