[System.Serializable]
public class Item
{
    public string name = "Item nulo";
    public int id;
    public int quantity;
    public string description = "Esse item pode ser usado para testar coisas.";
    public int health = 0;
    public int damage = 0;
    public int defense = 0;
    public int speed = 0;
    public int burnResist = 0;
    public int poisonResist = 0;
    public int paralyseResist = 0;
    public int fearResist = 0;

    public enum Type
    {
        item,
        helmet,
        armor,
        legs,
        sword,
        dagger,
        axe,
        notFound
    };

    public Type equipType = Type.item;


    public override bool Equals(object other)
    {
        if (other == null)
            return false;

        Item objAsItem = other as Item;
        if (objAsItem == null)
            return false;

        return this.id.Equals(objAsItem.id);
    }

    public override int GetHashCode()
    {
        return id;
    }
    public override string ToString()
    {
        return name;
    }

    public void Clone(Item other)
    {
        id = other.id;
        name = other.name;
        description = other.description;
        quantity = other.quantity;
        health = other.health;
        damage = other.damage;
        defense = other.defense;
        speed = other.speed;
        burnResist = other.burnResist;
        poisonResist = other.poisonResist;
        paralyseResist = other.paralyseResist;
        fearResist = other.fearResist;
        equipType = other.equipType;
    }

    public Type GetEquipType(string typeString)
    {
        switch (typeString)
        {
            case "item":
                return Type.item;
            case "helmet":
                return Type.helmet;
            case "armor":
                return Type.armor;
            case "legs":
                return Type.legs;
            case "sword":
                return Type.sword;
            case "dagger":
                return Type.dagger;
            case "axe":
                return Type.axe;
            default:
                return Type.notFound;
        }
    }
}
