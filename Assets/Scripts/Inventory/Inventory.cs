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
        Debug.Log("Item recebido: " + item.name);
        if (items.Contains(item))
        {
            Debug.Log("Item encontrado, aumentando quantidade em: " + item.quantity);

            items[items.IndexOf(item)].quantity += item.quantity;
        }
        else{
            Debug.Log("Item não encontrado, adicionando");

            items.Add(item);
        }
    }

    public void Remove(Item item)
    {
        Debug.Log("Quantidade recebida: " + item.quantity + " Id: " + item.id);
        Debug.Log("Quantidade antes: " + items[items.IndexOf(item)].quantity);

        items[items.IndexOf(item)].quantity -= item.quantity;

        Debug.Log("Quantidade depois: " + items[items.IndexOf(item)].quantity);

        if (items[items.IndexOf(item)].quantity == 0)
        {
            Debug.Log("Removendo");
            items.Remove(item);
        }

    }
}
