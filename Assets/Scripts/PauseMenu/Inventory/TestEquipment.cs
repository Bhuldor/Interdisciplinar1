using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEquipment : MonoBehaviour
{
    private int id = 20;
    private string ItemName = "Equipamento Teste";
    public int quantity = 1;
    public void AddTestItem()
    {
        Equip test = new Equip
        {
            name = ItemName + " " + id,
            id = this.id,
            quantity = this.quantity,
            description = "Equipamento de teste",
            damage = 1,
            defense = -1,
            speed = 2,
            health = 5
        };
        id++;
        Inventory.instance.Add(test);
    }
}
