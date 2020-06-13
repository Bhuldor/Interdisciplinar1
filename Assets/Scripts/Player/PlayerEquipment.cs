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
                if (weapon.name != "Item nulo")
                    returnToInventory.Clone(weapon);
                weapon.Clone(equipment);
                //Sword-0 Axe-1 Dagger-2
                JoystickControl.instance.Change3dModel(0);
                break;
            case Item.Type.dagger:
                if (weapon.name != "Item nulo")
                    returnToInventory.Clone(weapon);
                weapon.Clone(equipment);
                //Sword-0 Axe-1 Dagger-2
                JoystickControl.instance.Change3dModel(2);
                break;
            case Item.Type.axe:
                if(weapon.name != "Item nulo")
                    returnToInventory.Clone(weapon);
                weapon.Clone(equipment);
                //Sword-0 Axe-1 Dagger-2
                JoystickControl.instance.Change3dModel(1);
                break;
            default:
                Debug.LogError("Equipamento passado não possui tipo compativel.");
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

    public int GetTotalEquipedDefense()
    {
        return helmet.defense + armor.defense + legs.defense + weapon.defense;
    }
    public int GetTotalEquipedDamage()
    {
        return helmet.damage + armor.damage + legs.damage + weapon.damage;
    }
    public int GetTotalEquipedSpeed()
    {
        return helmet.speed + armor.speed + legs.speed + weapon.speed;
    }
    public int GetTotalEquipedHealth()
    {
        return helmet.health + armor.health + legs.health + weapon.health;
    }
    public int GetTotalEquipedBurnResist()
    {
        return helmet.burnResist + armor.burnResist + legs.burnResist + weapon.burnResist;
    }
    public int GetTotalEquipedFearResist()
    {
        return helmet.fearResist + armor.fearResist + legs.fearResist + weapon.fearResist;
    }
    public int GetTotalEquipedParalyseResist()
    {
        return helmet.paralyseResist + armor.paralyseResist + legs.paralyseResist + weapon.paralyseResist;
    }
    public int GetTotalEquipedPoisonResist()
    {
        return helmet.poisonResist + armor.poisonResist + legs.poisonResist + weapon.poisonResist;
    }
}
