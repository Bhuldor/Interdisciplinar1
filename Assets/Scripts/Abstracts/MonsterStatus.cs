using UnityEngine;

public abstract class MonsterStatus : CharacterStatus
{
    protected float givenExp;
    public MonsterStatus(float atk, float def, float spd, float hp, float gExp) : base(atk, def, spd, hp)
    {
        attack = atk;
        defense = def;
        speed = spd;
        hitPoints = hp;
        givenExp = gExp;
    }

    public float getExp() { return givenExp; }

    public void getDrop()
    {
        Item item = new Item();
        int n = Random.Range(1, 100);
        if (n < 7) //6% no drop
        { //no drop
        }
        else if (n > 6 && n < 10) //3% item tier 3
        {
            int[] list = new int[18] { 6, 11, 16, 21, 25, 29, 33, 37, 41, 45, 49, 53, 57, 61, 65, 72, 76, 80 };
            int rdn = Random.Range(0, list.Length);
            int index = list[rdn];
            item.Clone(Inventory.instance.GetItemByID(index));
            item.quantity = 1;
            Inventory.instance.ObtainDrop(item);
        }
        else if (n > 9 && n < 33) // 23% tecido
        {
            item.Clone(Inventory.instance.GetItemByID(3));
            item.quantity = 5;
            Inventory.instance.ObtainDrop(item);
        }
        else if (n > 32 && n < 56) // 23% metal
        {
            item.Clone(Inventory.instance.GetItemByID(1));
            item.quantity = 5;
            Inventory.instance.ObtainDrop(item);
        }
        else if (n > 55 && n < 79) // 23% pedra preciosa
        {
            item.Clone(Inventory.instance.GetItemByID(2));
            item.quantity = 5;
            Inventory.instance.ObtainDrop(item);
        }
        else if (n > 78 && n < 86) //7% item tier 2
        {
            int[] list = new int[18] { 5, 10, 15, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64, 70, 74, 78 };
            int rdn = Random.Range(0, list.Length);
            int index = list[rdn];
            item.Clone(Inventory.instance.GetItemByID(index));
            item.quantity = 1;
            Inventory.instance.ObtainDrop(item);
        }
        else //15% item tier 1
        {
            int[] list = new int[18] { 4, 9, 14, 19, 23, 27, 31, 35, 39, 43, 47, 51, 55, 59, 63, 67, 68, 69 };
            int rdn = Random.Range(0, list.Length);
            int index = list[rdn];
            item.Clone(Inventory.instance.GetItemByID(index));
            item.quantity = 1;
            Inventory.instance.ObtainDrop(item);
        }
    }
}
