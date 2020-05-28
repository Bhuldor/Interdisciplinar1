using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private int givenExpPoints;    
    [SerializeField] private List<int> givenItensIDs;
    private PlayerStatus player;

    public void GetTreasure()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStatus>();
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
