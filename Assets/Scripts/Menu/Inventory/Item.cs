public class Item
{
    public string name = "New Item";
    public int id;
    public int quantity;
    public string description = "Esse item pode ser usado para testar coisas.";

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
}
