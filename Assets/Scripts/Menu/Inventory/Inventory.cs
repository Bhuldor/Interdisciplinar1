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
        StartCoroutine(ReadFromStreamingAssets());
    }

    #endregion 

    public List<Item> items = new List<Item>();

    public delegate void DropObtain(Item item);
    public static event DropObtain OnDropObtain;

    string choosenLanguage = "PT-BR";

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

    public void ObtainDrop(Item item)
    {
        OnDropObtain?.Invoke(item);
        Add(item);
    }

    System.Collections.IEnumerator ReadFromStreamingAssets()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath,
                                                 "ItemList_" + choosenLanguage + ".txt");
        string result = "";
        if (filePath.Contains("://") || filePath.Contains(":///"))
        {
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
            yield return www.SendWebRequest();
            result = www.downloadHandler.text;
        }
        else
        {
            result = System.IO.File.ReadAllText(filePath);
        }

        string[] resultList = result.Split('$');
        string[] item;
        for (int a = 1; a < resultList.Length - 1; a++)
        {
            item = resultList[a].Split('|');
            var itemToAdd = CreateItem(item);
            if (itemToAdd != null)
            {
                Inventory.instance.Add(itemToAdd);
            }
        }
    }

    private Item CreateItem(string[] item)
    {
        try
        {
            switch (item[3])
            {
                case "S":
                    Equip equipToAdd = new Equip
                    {
                        id = int.Parse(item[0]),
                        name = item[1],
                        quantity = 0,
                        description = item[2],
                        health = int.Parse(item[4]),
                        damage = int.Parse(item[5]),
                        defense = int.Parse(item[6]),
                        speed = int.Parse(item[7]),
                        burnResist = int.Parse(item[8]),
                        poisonResist = int.Parse(item[9]),
                        paralyseResit = int.Parse(item[10]),
                        fearResist = int.Parse(item[11])
                    };
                    return equipToAdd;
                case "N":
                    Item itemToAdd = new Item
                    {
                        id = int.Parse(item[0]),
                        name = item[1],
                        quantity = 0,
                        description = item[2],
                    };
                    return itemToAdd;
            }
        }
        catch (System.Exception error)
        {
            Debug.LogError(error);
        }
        return null;
    }
}
