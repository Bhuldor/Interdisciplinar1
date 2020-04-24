using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInventory : MonoBehaviour
{
    public Text descriptionText;
    public Text descriptionStatusText;
    public Text descriptionBurn;
    public Text descriptionPoison;
    public Text descriptionParalyse;
    public Text descriptionFear;
    public Text equipButtonText;

    public Text helmetEquipedName;
    public Text helmetEquipedStatus;
    public Text helmetEquipedBurn;
    public Text helmetEquipedPoison;
    public Text helmetEquipedParalyse;
    public Text helmetEquipedFear;

    public Text armorEquipedName;
    public Text armorEquipedStatus;
    public Text armorEquipedBurn;
    public Text armorEquipedPoison;
    public Text armorEquipedParalyse;
    public Text armorEquipedFear;

    public Text legsEquipedName;
    public Text legsEquipedStatus;
    public Text legsEquipedBurn;
    public Text legsEquipedPoison;
    public Text legsEquipedParalyse;
    public Text legsEquipedFear;

    public Text weaponEquipedName;
    public Text weaponEquipedStatus;
    public Text weaponEquipedBurn;
    public Text weaponEquipedPoison;
    public Text weaponEquipedParalyse;
    public Text weaponEquipedFear;

    public GameObject inventoryPanel;
    public GameObject inventoryContentPanel;
    public GameObject descriptionPanel;
    public GameObject equipedPanel;
    public Menu menu;

    public VerifyEquipmentPower verifyEquip;

    public Button equipButton;
    
    public delegate void OpeningInventory();
    public static event OpeningInventory OnOpeningInventory;

    public static bool inventoryPanelIsOpen = false;
    private Equip inventory_SelectedEquip;


    public void OpenInventory()
    {
        if (inventoryPanelIsOpen)
        {
            menu.CloseOpenedPanels();
            return;
        }
        menu.CloseOpenedPanels();
        inventoryPanelIsOpen = true;
        LoadInventory();
    }
    private void LoadInventory()
    {
        LeanTween.scale(descriptionPanel, new Vector3(1, 1, 1), 0.1f);
        LeanTween.scale(equipedPanel, new Vector3(1, 1, 1), 0.1f);
        int count = inventoryContentPanel.transform.childCount;
        if (count != 0)
        {
            for (int a = 0; a < count; a++)
            {
                Destroy(inventoryContentPanel.transform.GetChild(a).gameObject);
            }
        }

        count = 0;

        foreach (Item i in Inventory.instance.items)
        {
            if (i.quantity > 0)
            {
                count++;
                GameObject newItem = new GameObject(i.name);
                var itemText = newItem.AddComponent<Text>();
                var newButton = newItem.AddComponent<Button>();

                itemText.text = $"{i.name} x{i.quantity}";
                itemText.font = FindObjectOfType<GameManager>().defauldFont;
                itemText.color = Color.black;
                itemText.rectTransform.sizeDelta = new Vector2(170, 35);
                itemText.transform.SetParent(newButton.transform);
                newButton.transform.SetParent(inventoryContentPanel.transform);
                newButton.onClick.AddListener(() => ClickOnItem(i));

                if (count == 1)
                {
                    ClickOnItem(i);
                }

                LeanTween.scale(newItem, new Vector3(1, 1, 1), 0.1f);
            }
        }
        LeanTween.scale(inventoryPanel, new Vector3(1, 1, 1), 0.1f);
        OnOpeningInventory?.Invoke();
        if (count == 0)
        {
            descriptionStatusText.text = "";
            descriptionText.text = "";
            equipButtonText.text = "";
            descriptionBurn.text = "";
            descriptionFear.text = "";
            descriptionParalyse.text = "";
            descriptionPoison.text = "";
            verifyEquip.HideImgs();
        }
    }

    public void ClickOnItem(Item item)
    {
        UpdateEquipedPanel();
        UpdateDescriptionpanel(item);
    }

    private void UpdateEquipedPanel()
    {
        if (PlayerEquipment.instance.helmet.name != "Item nulo")
        {
            helmetEquipedName.text = $"Capacete: {PlayerEquipment.instance.helmet.name}";
            helmetEquipedStatus.text = $"Vida: { PlayerEquipment.instance.helmet.health} | Ataque: { PlayerEquipment.instance.helmet.damage} | Defesa: { PlayerEquipment.instance.helmet.defense} | Veloc.: { PlayerEquipment.instance.helmet.speed}";
            helmetEquipedBurn.text = $"Que.: { PlayerEquipment.instance.helmet.burnResist}%";
            helmetEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.helmet.poisonResist}%";
            helmetEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.helmet.paralyseResist}%";
            helmetEquipedFear.text = $"Med.: { PlayerEquipment.instance.helmet.fearResist}% ";
        }
        else
        {
            helmetEquipedName.text = $"Capacete: -- ";
            helmetEquipedStatus.text = $"Vida: -- | Ataque: -- | Defesa: -- | Veloc.: --";
            helmetEquipedBurn.text = $"Que.: 0%";
            helmetEquipedPoison.text = $"Ven.: 0%";
            helmetEquipedParalyse.text = $"Par.: 0%";
            helmetEquipedFear.text = $"Med.: 0%";
        }

        if (PlayerEquipment.instance.armor.name != "Item nulo")
        {
            armorEquipedName.text = $"Armadura: {PlayerEquipment.instance.armor.name}";
            armorEquipedStatus.text = $"Vida: { PlayerEquipment.instance.armor.health} | Ataque: { PlayerEquipment.instance.armor.damage} | Defesa: { PlayerEquipment.instance.armor.defense} | Veloc.: { PlayerEquipment.instance.armor.speed}";
            armorEquipedBurn.text = $"Que.: { PlayerEquipment.instance.armor.burnResist}%";
            armorEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.armor.poisonResist}%";
            armorEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.armor.paralyseResist}%";
            armorEquipedFear.text = $"Med.: { PlayerEquipment.instance.armor.fearResist}% ";
        }
        else
        {
            armorEquipedName.text = $"Armadura: -- ";
            armorEquipedStatus.text = $"Vida: -- | Ataque: -- | Defesa: -- | Veloc.: --";
            armorEquipedBurn.text = $"Que.: 0%";
            armorEquipedPoison.text = $"Ven.: 0%";
            armorEquipedParalyse.text = $"Par.: 0%";
            armorEquipedFear.text = $"Med.: 0%";
        }

        if (PlayerEquipment.instance.legs.name != "Item nulo")
        {
            legsEquipedName.text = $"Calça: {PlayerEquipment.instance.legs.name}";
            legsEquipedStatus.text = $"Vida: { PlayerEquipment.instance.legs.health} | Ataque: { PlayerEquipment.instance.legs.damage} | Defesa: { PlayerEquipment.instance.legs.defense} | Veloc.: { PlayerEquipment.instance.legs.speed}";
            legsEquipedBurn.text = $"Que.: { PlayerEquipment.instance.legs.burnResist}%";
            legsEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.legs.poisonResist}%";
            legsEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.legs.paralyseResist}%";
            legsEquipedFear.text = $"Med.: { PlayerEquipment.instance.legs.fearResist}% ";
        }
        else
        {
            legsEquipedName.text = $"Calça: -- ";
            legsEquipedStatus.text = $"Vida: -- | Ataque: -- | Defesa: -- | Veloc.: --";
            legsEquipedBurn.text = $"Que.: 0%";
            legsEquipedPoison.text = $"Ven.: 0%";
            legsEquipedParalyse.text = $"Par.: 0%";
            legsEquipedFear.text = $"Med.: 0%";
        }

        if (PlayerEquipment.instance.weapon.name != "Item nulo")
        {
            weaponEquipedName.text = $"Arma: {PlayerEquipment.instance.weapon.name}";
            weaponEquipedStatus.text = $"Vida: { PlayerEquipment.instance.weapon.health} | Ataque: { PlayerEquipment.instance.weapon.damage} | Defesa: { PlayerEquipment.instance.weapon.defense} | Veloc.: { PlayerEquipment.instance.weapon.speed}";
            weaponEquipedBurn.text = $"Que.: { PlayerEquipment.instance.weapon.burnResist}%";
            weaponEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.weapon.poisonResist}%";
            weaponEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.weapon.paralyseResist}%";
            weaponEquipedFear.text = $"Med.: { PlayerEquipment.instance.weapon.fearResist}% ";
        }
        else
        {
            weaponEquipedName.text = "Arma: --";
            weaponEquipedStatus.text = $"Vida: -- | Ataque: -- | Defesa: -- | Veloc.: --";
            weaponEquipedBurn.text = $"Que.: 0%";
            weaponEquipedPoison.text = $"Ven.: 0%";
            weaponEquipedParalyse.text = $"Par.: 0%";
            weaponEquipedFear.text = $"Med.: 0%";
        }
    }

    private void UpdateDescriptionpanel(Item item)
    {
        descriptionText.text = $"{item.name} \n {item.description}";
        if (item is Equip)
        {
            Equip equip = item as Equip;
            inventory_SelectedEquip = equip;
            descriptionStatusText.text = $"Vida: {equip.health} \nAtaque: {equip.damage} \nDefesa: {equip.defense} \nVelocidade: {equip.speed}";
            descriptionBurn.text = $"Resist. Queimar: {equip.burnResist}%";
            descriptionPoison.text = $"Resist. Veneno: {equip.poisonResist}%";
            descriptionParalyse.text = $"Resist. Paralisia: {equip.paralyseResist}%";
            descriptionFear.text = $"Resist. Medo: {equip.fearResist}%";
            equipButton.enabled = true;
            equipButtonText.text = "Equipar";
            verifyEquip.VerifyEquipPower(equip);
        }
        else
        {
            descriptionStatusText.text = $"Vida: -- \nAtaque: -- \nDefesa: -- \nVelocidade: --";
            equipButton.enabled = false;
            equipButtonText.text = "";
            verifyEquip.HideImgs();
        }
    }

    public void EquipButton()
    {
        if (PlayerEquipment.instance.EquipToPlayer(inventory_SelectedEquip))
        {
            LoadInventory();
            UpdateEquipedPanel();
        }
    }

    public void UnequipHelmet()
    {
        if(PlayerEquipment.instance.helmet.name != "Item nulo")
        {
            if (PlayerEquipment.instance.Unequip(Equip.Type.helmet))
            {
                LoadInventory();
                UpdateEquipedPanel();
            }
        }
    }
    public void UnequipArmor()
    {
        if (PlayerEquipment.instance.armor.name != "Item nulo")
        {
            if (PlayerEquipment.instance.Unequip(Equip.Type.armor))
            {
                LoadInventory();
                UpdateEquipedPanel();
            }
        }
    }
    public void UnequipLegs()
    {
        if (PlayerEquipment.instance.legs.name != "Item nulo")
        {
            if (PlayerEquipment.instance.Unequip(Equip.Type.legs))
            {
                LoadInventory();
                UpdateEquipedPanel();
            }
        }
    }
    public void UnequipWeapon()
    {
        if (PlayerEquipment.instance.weapon.name != "Item nulo")
        {
            if (PlayerEquipment.instance.Unequip(Equip.Type.sword))
            {
                LoadInventory();
                UpdateEquipedPanel();
            }
        }
    }
}