using UnityEngine.UI;
using UnityEngine;

public class VerifyEquipmentPower : MonoBehaviour
{
    public Image imgHealth;
    public Image imgDamage;
    public Image imgDefense;
    public Image imgSpeed;
    public Image imgBurn;
    public Image imgPoison;
    public Image imgParalyse;
    public Image imgFear;

    public Sprite spriteUp;
    public Sprite spriteDown;

    public void VerifyEquipPower(Item item)
    {
        switch (item.equipType)
        {
            case Item.Type.armor:
                VerifyArmor(item);
                break;
            case Item.Type.helmet:
                VerifyHelmet(item);
                break;
            case Item.Type.legs:
                VerifyLegs(item);
                break;
            case Item.Type.sword:
            case Item.Type.axe:
            case Item.Type.dagger:
                VerifyWeapon(item);
                break;
        }
    }
    private void VerifyArmor(Item item)
    {
        if (PlayerEquipment.instance.armor.health < item.health)
            ChangeImg(imgHealth, Color.green);
        else if (PlayerEquipment.instance.armor.health > item.health)
            ChangeImg(imgHealth, Color.red);
        else
            imgHealth.enabled = false;

        if (PlayerEquipment.instance.armor.damage < item.damage)
            ChangeImg(imgDamage, Color.green);
        else if (PlayerEquipment.instance.armor.damage > item.damage)
            ChangeImg(imgDamage, Color.red);
        else
            imgDamage.enabled = false;

        if (PlayerEquipment.instance.armor.defense < item.defense)
            ChangeImg(imgDefense, Color.green);
        else if (PlayerEquipment.instance.armor.defense > item.defense)
            ChangeImg(imgDefense, Color.red);
        else
            imgDefense.enabled = false;

        if (PlayerEquipment.instance.armor.speed < item.speed)
            ChangeImg(imgSpeed, Color.green);
        else if (PlayerEquipment.instance.armor.speed > item.speed)
            ChangeImg(imgSpeed, Color.red);
        else
            imgSpeed.enabled = false;

        if (PlayerEquipment.instance.armor.burnResist < item.burnResist)
            ChangeImg(imgBurn, Color.green);
        else if (PlayerEquipment.instance.armor.burnResist > item.burnResist)
            ChangeImg(imgBurn, Color.red);
        else
            imgBurn.enabled = false;

        if (PlayerEquipment.instance.armor.poisonResist < item.poisonResist)
            ChangeImg(imgPoison, Color.green);
        else if (PlayerEquipment.instance.armor.poisonResist > item.poisonResist)
            ChangeImg(imgPoison, Color.red);
        else
            imgPoison.enabled = false;

        if (PlayerEquipment.instance.armor.paralyseResist < item.paralyseResist)
            ChangeImg(imgParalyse, Color.green);
        else if (PlayerEquipment.instance.armor.paralyseResist > item.paralyseResist)
            ChangeImg(imgParalyse, Color.red);
        else
            imgParalyse.enabled = false;

        if (PlayerEquipment.instance.armor.fearResist < item.fearResist)
            ChangeImg(imgFear, Color.green);
        else if (PlayerEquipment.instance.armor.fearResist > item.fearResist)
            ChangeImg(imgFear, Color.red);
        else
            imgFear.enabled = false;
    }
    private void VerifyLegs(Item item) {
        if (PlayerEquipment.instance.legs.health < item.health)
            ChangeImg(imgHealth, Color.green);
        else if (PlayerEquipment.instance.legs.health > item.health)
            ChangeImg(imgHealth, Color.red);
        else
            imgHealth.enabled = false;

        if (PlayerEquipment.instance.legs.damage < item.damage)
            ChangeImg(imgDamage, Color.green);
        else if (PlayerEquipment.instance.legs.damage > item.damage)
            ChangeImg(imgDamage, Color.red);
        else
            imgDamage.enabled = false;

        if (PlayerEquipment.instance.legs.defense < item.defense)
            ChangeImg(imgDefense, Color.green);
        else if (PlayerEquipment.instance.legs.defense > item.defense)
            ChangeImg(imgDefense, Color.red);
        else
            imgDefense.enabled = false;

        if (PlayerEquipment.instance.legs.speed < item.speed)
            ChangeImg(imgSpeed, Color.green);
        else if (PlayerEquipment.instance.legs.speed > item.speed)
            ChangeImg(imgSpeed, Color.red);
        else
            imgSpeed.enabled = false;

        if (PlayerEquipment.instance.legs.burnResist < item.burnResist)
            ChangeImg(imgBurn, Color.green);
        else if (PlayerEquipment.instance.legs.burnResist > item.burnResist)
            ChangeImg(imgBurn, Color.red);
        else
            imgBurn.enabled = false;

        if (PlayerEquipment.instance.legs.poisonResist < item.poisonResist)
            ChangeImg(imgPoison, Color.green);
        else if (PlayerEquipment.instance.legs.poisonResist > item.poisonResist)
            ChangeImg(imgPoison, Color.red);
        else
            imgPoison.enabled = false;

        if (PlayerEquipment.instance.legs.paralyseResist < item.paralyseResist)
            ChangeImg(imgParalyse, Color.green);
        else if (PlayerEquipment.instance.legs.paralyseResist > item.paralyseResist)
            ChangeImg(imgParalyse, Color.red);
        else
            imgParalyse.enabled = false;

        if (PlayerEquipment.instance.legs.fearResist < item.fearResist)
            ChangeImg(imgFear, Color.green);
        else if (PlayerEquipment.instance.legs.fearResist > item.fearResist)
            ChangeImg(imgFear, Color.red);
        else
            imgFear.enabled = false;
    }
    private void VerifyHelmet(Item item) 
    {
        if (PlayerEquipment.instance.helmet.health < item.health)
            ChangeImg(imgHealth, Color.green);
        else if (PlayerEquipment.instance.helmet.health > item.health)
            ChangeImg(imgHealth, Color.red);
        else
            imgHealth.enabled = false;

        if (PlayerEquipment.instance.helmet.damage < item.damage)
            ChangeImg(imgDamage, Color.green);
        else if (PlayerEquipment.instance.helmet.damage > item.damage)
            ChangeImg(imgDamage, Color.red);
        else
            imgDamage.enabled = false;

        if (PlayerEquipment.instance.helmet.defense < item.defense)
            ChangeImg(imgDefense, Color.green);
        else if (PlayerEquipment.instance.helmet.defense > item.defense)
            ChangeImg(imgDefense, Color.red);
        else
            imgDefense.enabled = false;

        if (PlayerEquipment.instance.helmet.speed < item.speed)
            ChangeImg(imgSpeed, Color.green);
        else if (PlayerEquipment.instance.helmet.speed > item.speed)
            ChangeImg(imgSpeed, Color.red);
        else
            imgSpeed.enabled = false;

        if (PlayerEquipment.instance.helmet.burnResist < item.burnResist)
            ChangeImg(imgBurn, Color.green);
        else if (PlayerEquipment.instance.helmet.burnResist > item.burnResist)
            ChangeImg(imgBurn, Color.red);
        else
            imgBurn.enabled = false;

        if (PlayerEquipment.instance.helmet.poisonResist < item.poisonResist)
            ChangeImg(imgPoison, Color.green);
        else if (PlayerEquipment.instance.helmet.poisonResist > item.poisonResist)
            ChangeImg(imgPoison, Color.red);
        else
            imgPoison.enabled = false;

        if (PlayerEquipment.instance.helmet.paralyseResist < item.paralyseResist)
            ChangeImg(imgParalyse, Color.green);
        else if (PlayerEquipment.instance.helmet.paralyseResist > item.paralyseResist)
            ChangeImg(imgParalyse, Color.red);
        else
            imgParalyse.enabled = false;

        if (PlayerEquipment.instance.helmet.fearResist < item.fearResist)
            ChangeImg(imgFear, Color.green);
        else if (PlayerEquipment.instance.helmet.fearResist > item.fearResist)
            ChangeImg(imgFear, Color.red);
        else
            imgFear.enabled = false;
    }
    private void VerifyWeapon(Item item) 
    {
        if (PlayerEquipment.instance.weapon.health < item.health)
            ChangeImg(imgHealth, Color.green);
        else if (PlayerEquipment.instance.weapon.health > item.health)
            ChangeImg(imgHealth, Color.red);
        else
            imgHealth.enabled = false;

        if (PlayerEquipment.instance.weapon.damage < item.damage)
            ChangeImg(imgDamage, Color.green);
        else if (PlayerEquipment.instance.weapon.damage > item.damage)
            ChangeImg(imgDamage, Color.red);
        else
            imgDamage.enabled = false;

        if (PlayerEquipment.instance.weapon.defense < item.defense)
            ChangeImg(imgDefense, Color.green);
        else if (PlayerEquipment.instance.weapon.defense > item.defense)
            ChangeImg(imgDefense, Color.red);
        else
            imgDefense.enabled = false;

        if (PlayerEquipment.instance.weapon.speed < item.speed)
            ChangeImg(imgSpeed, Color.green);
        else if (PlayerEquipment.instance.weapon.speed > item.speed)
            ChangeImg(imgSpeed, Color.red);
        else
            imgSpeed.enabled = false;

        if (PlayerEquipment.instance.weapon.burnResist < item.burnResist)
            ChangeImg(imgBurn, Color.green);
        else if (PlayerEquipment.instance.weapon.burnResist > item.burnResist)
            ChangeImg(imgBurn, Color.red);
        else
            imgBurn.enabled = false;

        if (PlayerEquipment.instance.weapon.poisonResist < item.poisonResist)
            ChangeImg(imgPoison, Color.green);
        else if (PlayerEquipment.instance.weapon.poisonResist > item.poisonResist)
            ChangeImg(imgPoison, Color.red);
        else
            imgPoison.enabled = false;

        if (PlayerEquipment.instance.weapon.paralyseResist < item.paralyseResist)
            ChangeImg(imgParalyse, Color.green);
        else if (PlayerEquipment.instance.weapon.paralyseResist > item.paralyseResist)
            ChangeImg(imgParalyse, Color.red);
        else
            imgParalyse.enabled = false;

        if (PlayerEquipment.instance.weapon.fearResist < item.fearResist)
            ChangeImg(imgFear, Color.green);
        else if (PlayerEquipment.instance.weapon.fearResist > item.fearResist)
            ChangeImg(imgFear, Color.red);
        else
            imgFear.enabled = false;
    }

    private void ChangeImg(Image img, Color color)
    {
        img.color = color;
        if (color == Color.green)
            img.sprite = spriteUp;
        else
            img.sprite = spriteDown;
        img.enabled = true;
    }

    public void HideImgs()
    {
        imgBurn.enabled = false;
        imgDamage.enabled = false;
        imgDefense.enabled = false;
        imgFear.enabled = false;
        imgHealth.enabled = false;
        imgParalyse.enabled = false;
        imgPoison.enabled = false;
        imgSpeed.enabled = false;
    }
}
