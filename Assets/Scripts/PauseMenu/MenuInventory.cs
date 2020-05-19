using UnityEngine;
using UnityEngine.UI;

public class MenuInventory : MonoBehaviour
{
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text descriptionLifeText;
    [SerializeField] private Text descriptionDamageText;
    [SerializeField] private Text descriptionDefenseText;
    [SerializeField] private Text descriptionSpeedText;
    [SerializeField] private Text descriptionBurn;
    [SerializeField] private Text descriptionPoison;
    [SerializeField] private Text descriptionParalyse;
    [SerializeField] private Text descriptionFear;
    [SerializeField] private Text equipButtonText;

    [SerializeField] private Text helmetEquipedName;
    [SerializeField] private Text helmetEquipedLife;
    [SerializeField] private Text helmetEquipedDamage;
    [SerializeField] private Text helmetEquipedDefense;
    [SerializeField] private Text helmetEquipedSpeed;
    [SerializeField] private Text helmetEquipedBurn;
    [SerializeField] private Text helmetEquipedPoison;
    [SerializeField] private Text helmetEquipedParalyse;
    [SerializeField] private Text helmetEquipedFear;

    [SerializeField] private Text armorEquipedName;
    [SerializeField] private Text armorEquipedLife;
    [SerializeField] private Text armorEquipedDamage;
    [SerializeField] private Text armorEquipedDefense;
    [SerializeField] private Text armorEquipedSpeed;
    [SerializeField] private Text armorEquipedBurn;
    [SerializeField] private Text armorEquipedPoison;
    [SerializeField] private Text armorEquipedParalyse;
    [SerializeField] private Text armorEquipedFear;

    [SerializeField] private Text legsEquipedName;
    [SerializeField] private Text legsEquipedLife;
    [SerializeField] private Text legsEquipedDamage;
    [SerializeField] private Text legsEquipedDefense;
    [SerializeField] private Text legsEquipedSpeed;
    [SerializeField] private Text legsEquipedBurn;
    [SerializeField] private Text legsEquipedPoison;
    [SerializeField] private Text legsEquipedParalyse;
    [SerializeField] private Text legsEquipedFear;

    [SerializeField] private Text weaponEquipedName;
    [SerializeField] private Text weaponEquipedLife;
    [SerializeField] private Text weaponEquipedDamage;
    [SerializeField] private Text weaponEquipedDefense;
    [SerializeField] private Text weaponEquipedSpeed;
    [SerializeField] private Text weaponEquipedBurn;
    [SerializeField] private Text weaponEquipedPoison;
    [SerializeField] private Text weaponEquipedParalyse;
    [SerializeField] private Text weaponEquipedFear;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryContentPanel;
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private GameObject equipedPanel;
    [SerializeField] private Menu menu;

    public FadeEffect fadeEffect;
    public VerifyEquipmentPower verifyEquip;

    [SerializeField] private Button equipButton;
    
    public delegate void OpeningInventory(int childCount, float childSizeY);
    public static event OpeningInventory OnOpeningInventory;

    public static bool inventoryPanelIsOpen = false;
    private Item inventory_SelectedEquip;

    [SerializeField] private  GameObject prefabListItem;

    private bool shouldUpdate = false;

    private CanvasGroup equipedCanvas;
    private CanvasGroup descriptionCanvas;
    private CanvasGroup inventoryCanvas;

    private void Start()
    {
        equipedCanvas = equipedPanel.gameObject.GetComponent<CanvasGroup>();
        descriptionCanvas = descriptionPanel.gameObject.GetComponent<CanvasGroup>();
        inventoryCanvas = inventoryPanel.gameObject.GetComponent<CanvasGroup>();
    }
    public void OpenInventory()
    {

        //{
        //    menu.CloseOpenedPanels();
        //    return;
        //}
        if (!inventoryPanelIsOpen)
        {
            menu.CloseOpenedPanels();
            inventoryPanelIsOpen = true;
            fadeEffect.Activated = true;
            LoadInventory();
        }
    }
    private void LoadInventory()
    {
        LeanTween.scale(descriptionPanel, new Vector3(1, 1, 1), 0f);
        LeanTween.scale(equipedPanel, new Vector3(1, 1, 1), 0f);
        LeanTween.alphaCanvas(equipedCanvas, 1, 0.1f);
        LeanTween.alphaCanvas(descriptionCanvas, 1, 0.1f);
        int count = inventoryContentPanel.transform.childCount;
        if (count != 0)
        {
            for (int a = 0; a < count; a++)
            {
                Destroy(inventoryContentPanel.transform.GetChild(a).gameObject);
            }
        }

        count = 0;
        shouldUpdate = true;

    }

    private void FixedUpdate()
    {
        if (shouldUpdate)
        {
            var inventoryRT = inventoryContentPanel.GetComponent<RectTransform>();
            float sizeY = inventoryRT.rect.width / 8;
            float sizeX = inventoryRT.rect.width;
            int count = 0;
            foreach (Item i in Inventory.instance.items)
            {
                if (i.quantity > 0)
                {
                    count++;
                    GameObject newItem = Instantiate(prefabListItem);
                    var itemText = newItem.GetComponentInChildren<Text>();
                    var newButton = newItem.GetComponent<Button>();
                    newButton.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX, sizeY);
                    itemText.text = $"{i.name} x{i.quantity}";
                    //itemText.font = FindObjectOfType<GameManager>().defauldFont;
                    itemText.color = Color.black;
                    newItem.transform.SetParent(inventoryContentPanel.transform);
                    newButton.onClick.AddListener(() => ClickOnItem(i));

                    if (count == 1)
                    {
                        ClickOnItem(i);
                    }

                    LeanTween.scale(newItem, new Vector3(1f, 1f, 1f), 0f);
                }

            }
            OnOpeningInventory?.Invoke(count, sizeY);
            LeanTween.scale(inventoryPanel, new Vector3(1, 1, 1), 0f);
            LeanTween.alphaCanvas(inventoryCanvas, 1, 0.1f);
            
            if (count == 0)
            {
                descriptionLifeText.text = "";
                descriptionDamageText.text = "";
                descriptionDefenseText.text = "";
                descriptionSpeedText.text = "";
                descriptionText.text = "";
                equipButtonText.text = "";
                descriptionBurn.text = "";
                descriptionFear.text = "";
                descriptionParalyse.text = "";
                descriptionPoison.text = "";
                verifyEquip.HideImgs();
            }
            shouldUpdate = false;
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
            helmetEquipedLife.text = $"{ PlayerEquipment.instance.helmet.health}";
            helmetEquipedDamage.text = $"{ PlayerEquipment.instance.helmet.damage}";
            helmetEquipedDefense.text = $"{ PlayerEquipment.instance.helmet.defense}";
            helmetEquipedSpeed.text = $"{ PlayerEquipment.instance.helmet.speed}";

            helmetEquipedBurn.text = $"Que.: { PlayerEquipment.instance.helmet.burnResist}%";
            helmetEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.helmet.poisonResist}%";
            helmetEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.helmet.paralyseResist}%";
            helmetEquipedFear.text = $"Med.: { PlayerEquipment.instance.helmet.fearResist}% ";
        }
        else
        {
            helmetEquipedName.text = $"Capacete: -- ";
            helmetEquipedLife.text = $"0";
            helmetEquipedDamage.text = $"0";
            helmetEquipedDefense.text = $"0";
            helmetEquipedSpeed.text = $"0";
            helmetEquipedBurn.text = $"Que.: 0%";
            helmetEquipedPoison.text = $"Ven.: 0%";
            helmetEquipedParalyse.text = $"Par.: 0%";
            helmetEquipedFear.text = $"Med.: 0%";
        }

        if (PlayerEquipment.instance.armor.name != "Item nulo")
        {
            armorEquipedName.text = $"Armadura: {PlayerEquipment.instance.armor.name}";
            armorEquipedLife.text = $"{ PlayerEquipment.instance.armor.health}";
            armorEquipedDamage.text = $"{ PlayerEquipment.instance.armor.damage}";
            armorEquipedDefense.text = $"{ PlayerEquipment.instance.armor.defense}";
            armorEquipedSpeed.text = $"{ PlayerEquipment.instance.armor.speed}";
            armorEquipedBurn.text = $"Que.: { PlayerEquipment.instance.armor.burnResist}%";
            armorEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.armor.poisonResist}%";
            armorEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.armor.paralyseResist}%";
            armorEquipedFear.text = $"Med.: { PlayerEquipment.instance.armor.fearResist}% ";
        }
        else
        {
            armorEquipedName.text = $"Armadura: -- ";
            armorEquipedLife.text = $"0";
            armorEquipedDamage.text = $"0";
            armorEquipedDefense.text = $"0";
            armorEquipedSpeed.text = $"0";
            armorEquipedBurn.text = $"Que.: 0%";
            armorEquipedPoison.text = $"Ven.: 0%";
            armorEquipedParalyse.text = $"Par.: 0%";
            armorEquipedFear.text = $"Med.: 0%";
        }

        if (PlayerEquipment.instance.legs.name != "Item nulo")
        {
            legsEquipedName.text = $"Calça: {PlayerEquipment.instance.legs.name}";
            legsEquipedLife.text = $"{ PlayerEquipment.instance.legs.health}";
            legsEquipedDamage.text = $"{ PlayerEquipment.instance.legs.damage}";
            legsEquipedDefense.text = $"{ PlayerEquipment.instance.legs.defense}";
            legsEquipedSpeed.text = $"{ PlayerEquipment.instance.legs.speed}";
            legsEquipedBurn.text = $"Que.: { PlayerEquipment.instance.legs.burnResist}%";
            legsEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.legs.poisonResist}%";
            legsEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.legs.paralyseResist}%";
            legsEquipedFear.text = $"Med.: { PlayerEquipment.instance.legs.fearResist}% ";
        }
        else
        {
            legsEquipedName.text = $"Calça: -- ";
            legsEquipedLife.text = $"0";
            legsEquipedDamage.text = $"0";
            legsEquipedDefense.text = $"0";
            legsEquipedSpeed.text = $"0";
            legsEquipedBurn.text = $"Que.: 0%";
            legsEquipedPoison.text = $"Ven.: 0%";
            legsEquipedParalyse.text = $"Par.: 0%";
            legsEquipedFear.text = $"Med.: 0%";
        }

        if (PlayerEquipment.instance.weapon.name != "Item nulo")
        {
            weaponEquipedName.text = $"Arma: {PlayerEquipment.instance.weapon.name}";
            weaponEquipedLife.text = $"{ PlayerEquipment.instance.weapon.health}";
            weaponEquipedDamage.text = $"{ PlayerEquipment.instance.weapon.damage}";
            weaponEquipedDefense.text = $"{ PlayerEquipment.instance.weapon.defense}";
            weaponEquipedSpeed.text = $"{ PlayerEquipment.instance.weapon.speed}";
            weaponEquipedBurn.text = $"Que.: { PlayerEquipment.instance.weapon.burnResist}%";
            weaponEquipedPoison.text = $"Ven.: { PlayerEquipment.instance.weapon.poisonResist}%";
            weaponEquipedParalyse.text = $"Par.: { PlayerEquipment.instance.weapon.paralyseResist}%";
            weaponEquipedFear.text = $"Med.: { PlayerEquipment.instance.weapon.fearResist}% ";
        }
        else
        {
            weaponEquipedName.text = "Arma: --";
            weaponEquipedLife.text = $"0";
            weaponEquipedDamage.text = $"0";
            weaponEquipedDefense.text = $"0";
            weaponEquipedSpeed.text = $"0";
            weaponEquipedBurn.text = $"Que.: 0%";
            weaponEquipedPoison.text = $"Ven.: 0%";
            weaponEquipedParalyse.text = $"Par.: 0%";
            weaponEquipedFear.text = $"Med.: 0%";
        }
    }

    private void UpdateDescriptionpanel(Item item)
    {
        descriptionText.text = $"{item.name} \n {item.description}";
        if (item.equipType != Item.Type.item)
        {
            inventory_SelectedEquip = item;
            descriptionLifeText.text = $" Vida: {item.health}";
            descriptionDamageText.text = $" Ataque: {item.damage}";
            descriptionDefenseText.text = $" Defesa: {item.defense}";
            descriptionSpeedText.text = $" Velocidade: {item.speed}";
            descriptionBurn.text = $" Resist. Queimar: {item.burnResist}%";
            descriptionPoison.text = $" Resist. Veneno: {item.poisonResist}%";
            descriptionParalyse.text = $" Resist. Paralisia: {item.paralyseResist}%";
            descriptionFear.text = $" Resist. Medo: {item.fearResist}%";
            equipButton.enabled = true;
            equipButtonText.text = "Equipar";
            verifyEquip.VerifyEquipPower(item);
        }
        else
        {
            descriptionLifeText.text = $" Vida: 0";
            descriptionDamageText.text = $" Ataque: 0";
            descriptionDefenseText.text = $" Defesa: 0";
            descriptionSpeedText.text = $" Velocidade: 0";
            descriptionBurn.text = $" Resist. Queimar: {item.burnResist}%";
            descriptionPoison.text = $" Resist. Veneno: {item.poisonResist}%";
            descriptionParalyse.text = $" Resist. Paralisia: {item.paralyseResist}%";
            descriptionFear.text = $" Resist. Medo: {item.fearResist}%";
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
            if (PlayerEquipment.instance.Unequip(Item.Type.helmet))
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
            if (PlayerEquipment.instance.Unequip(Item.Type.armor))
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
            if (PlayerEquipment.instance.Unequip(Item.Type.legs))
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
            if (PlayerEquipment.instance.Unequip(Item.Type.sword))
            {
                LoadInventory();
                UpdateEquipedPanel();
            }
        }
    }
}