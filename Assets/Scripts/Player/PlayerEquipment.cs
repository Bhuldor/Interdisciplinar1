using UnityEngine;

public class PlayerEquipment
{
    public Item helmet = new Item();
    public Item armor = new Item();
    public Item legs = new Item();
    public Item weapon = new Item();

    public static PlayerEquipment instance;


    public bool EquipToPlayer(Item equipment)
    {
        Item returnToInventory = new Item();
        switch (equipment.equipType)
        {
            case Item.Type.helmet:
                if (helmet.name != "Item nulo")
                    returnToInventory.Clone(helmet);
                helmet.Clone(equipment);
                break;
            case Item.Type.armor:
                if(armor.name != "Item nulo")
                    returnToInventory.Clone(armor);
                armor.Clone(equipment);
                break;
            case Item.Type.legs:
                if(legs.name != "Item nulo")
                    returnToInventory.Clone(legs);
                legs.Clone(equipment);
                break;
            case Item.Type.sword:
            case Item.Type.dagger:
            case Item.Type.axe:
                if(weapon.name != "Item nulo")
                    returnToInventory.Clone(weapon);
                weapon.Clone(equipment);
                break;
            default:
                Debug.LogWarning("Equipamento passado não possui tipo compativel.");
                return false;
        }
        if (returnToInventory.name != "Item nulo")
            Inventory.instance.Add(returnToInventory);
        if(equipment.name != "Item nulo")
            Inventory.instance.Remove(equipment);
        return true;
    }

    public bool Unequip(Item.Type type)
    {
        Item equipNulo = new Item();
        equipNulo.equipType = type;
        return EquipToPlayer(equipNulo);
    }
}
