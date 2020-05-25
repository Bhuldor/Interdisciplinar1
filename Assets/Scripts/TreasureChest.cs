using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private int givenExpPoints;
    [SerializeField] private PlayerStatus player;
    [SerializeField] private List<int> givenItensIDs;
    public void GetTreasure()
    {
        player.ObtainExp(givenExpPoints);

        foreach(int i in givenItensIDs)
        {
            var item = new Item();
            item.Clone(Inventory.instance.GetItemByID(i));
            item.quantity = 1;
            
            Inventory.instance.ObtainDrop(item);
        }

        Destroy(this.gameObject);
        
    }
}
