using UnityEngine;

public class PlayerEquipment
{
    public Equip helmet = new Equip();
    public Equip armor = new Equip();
    public Equip legs = new Equip();
    public Equip weapon = new Equip();

    public static PlayerEquipment instance;


    public bool EquipToPlayer(Equip equipment)
    {
        Equip returnToInventory = new Equip();
        switch (equipment.equipType)
        {
            case Equip.Type.helmet:
                if (helmet.name != "Item nulo")
                    returnToInventory.Clone(helmet);
                helmet.Clone(equipment);
                break;
            case Equip.Type.armor:
                if(armor.name != "Item nulo")
                    returnToInventory.Clone(armor);
                armor.Clone(equipment);
                break;
            case Equip.Type.legs:
                if(legs.name != "Item nulo")
                    returnToInventory.Clone(legs);
                legs.Clone(equipment);
                break;
            case Equip.Type.sword:
            case Equip.Type.dagger:
            case Equip.Type.axe:
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

    public bool Unequip(Equip.Type type)
    {
        Equip equipNulo = new Equip();
        equipNulo.equipType = type;
        return EquipToPlayer(equipNulo);
    }
}
