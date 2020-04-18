public class Equip : Item
{
    public int health = 0;
    public int damage = 0;
    public int defense = 0;
    public int speed = 0;
    public int burnResist = 0;
    public int poisonResist = 0;
    public int paralyseResit = 0;
    public int fearResist = 0;
    public enum Type { 
        helmet,
        armor,
        legs,
        sword,
        dagger,
        axe,
        notFound
    };

    public Type equipType = Type.notFound;

    public void Clone(Equip other)
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
        paralyseResit = other.paralyseResit;
        fearResist = other.fearResist;
        equipType = other.equipType;
    }

    public Type GetEquipType(string typeString)
    {
        switch (typeString)
        {
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

