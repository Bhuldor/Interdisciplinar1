using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image menuArrowImage;
    public GameObject menuPanel;
    public Sprite upArrowSprite;
    public Sprite downArrowSprite;
    public Sprite yesSprite;
    public Sprite noSprite;
    public Image soundImage;
    public Image musicImage;
    public Image effectsImage;
    public GameObject mapPanel;
    public GameObject profilePanel1;
    public GameObject profilePanel2;
    public GameObject inventoryPanel;
    public GameObject inventoryContentPanel;
    public GameObject settingsPanel;
    public GameObject descriptionPanel;
    public GameObject equipedPanel;
    public Image fadePanel;
    public Text descriptionText;
    public Text descriptionStatusText;
    public Text equipButtonText;
    public Text helmetEquipedText;
    public Text armorEquipedText;
    public Text legsEquipedText;
    public Text weaponEquipedText;
    public Button equipButton;
    public Font pixelFont;


    private bool menuIsOpen = false;

    private bool mapPanelIsOpen = false;
    private bool profilePanelIsOpen = false;
    private bool inventoryPanelIsOpen = false;
    private bool settingsPanelIsOpen = false;

    private bool soundIsOn = true;
    private bool musicIsOn = true;
    private bool effectsIsOn = true;

    private bool fading = false;

    private Equip inventory_SelectedEquip;

    public delegate void OpeningInventory();
    public static event OpeningInventory OnOpeningInventory;

    public void Start()
    {
        transform.position = new Vector3(Screen.width / 2, transform.position.y, transform.position.z);
    }
    public void OpenCloseMenu()
    {
        StartCoroutine(FadePanel());
        if (!menuIsOpen)
        {
            menuIsOpen = true;
            menuArrowImage.sprite = upArrowSprite;
            LeanTween.move(menuPanel, menuPanel.transform.position - new Vector3(0, Screen.height * 0.25f, 0), 0.1f);
        }
        else
        {
            menuIsOpen = false;
            menuArrowImage.sprite = downArrowSprite;
            LeanTween.move(menuPanel, menuPanel.transform.position + new Vector3(0, Screen.height * 0.25f, 0), 0.1f);
            CloseOpenedPanels();
        }
    }

    private IEnumerator FadePanel()
    {
        fading = true;
        fadePanel.enabled = true;
        float alpha = fadePanel.color.a;
        while (fading)
        {
            yield return null;
            if (!menuIsOpen) //needs to fadeOut
            {
                alpha -= 0.1f;
                fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, alpha);
                if (alpha <= 0)
                {
                    fading = false;
                    fadePanel.enabled = false;
                }
            }
            else //needs to fade in
            {
                alpha += 0.1f;
                fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, alpha);
                if (alpha >= 0.6f)
                    fading = false;
            }
        }
        
        
    }
    public void CloseOpenedPanels()
    {
        if (mapPanelIsOpen)
        {
            LeanTween.scale(mapPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            mapPanelIsOpen = false;
        }
        if (profilePanelIsOpen)
        {
            LeanTween.scale(profilePanel1, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            LeanTween.scale(profilePanel2, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            profilePanelIsOpen = false;
        }
            
        if (inventoryPanelIsOpen)
        {
            LeanTween.scale(inventoryPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            LeanTween.scale(descriptionPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            LeanTween.scale(equipedPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            inventoryPanelIsOpen = false;
        }
        if (settingsPanelIsOpen)
        {
            LeanTween.scale(settingsPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
            settingsPanelIsOpen = false;
        }
    }

    public void OpenMap()
    {
        if (mapPanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        CloseOpenedPanels();
        mapPanelIsOpen = true;
        LeanTween.scale(mapPanel, new Vector3(1, 1, 1), 0.1f);
    }

    public void OpenProfile()
    {
        if (profilePanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        CloseOpenedPanels();
        profilePanelIsOpen = true;
        LeanTween.scale(profilePanel1, new Vector3(1, 1, 1), 0.1f);
        LeanTween.scale(profilePanel2, new Vector3(1, 1, 1), 0.1f);
    }

    public void OpenInventory()
    {
        if (inventoryPanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        CloseOpenedPanels();
        inventoryPanelIsOpen = true;
        LoadInventory();
    }

    private void LoadInventory()
    {
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
                itemText.font = pixelFont;
                itemText.color = Color.black;
                itemText.rectTransform.sizeDelta = new Vector2(170, 35);
                itemText.transform.SetParent(newButton.transform);
                newButton.transform.SetParent(inventoryContentPanel.transform);
                newButton.onClick.AddListener(() => ClickOnItem(i));

                if(count == 1)
                {
                    ClickOnItem(i);
                }

                LeanTween.scale(newItem, new Vector3(1, 1, 1), 0.1f);
            }
        }
        LeanTween.scale(inventoryPanel, new Vector3(1, 1, 1), 0.1f);
        OnOpeningInventory?.Invoke();
        
    }

    public void ClickOnItem(Item item)
    {
        LeanTween.scale(descriptionPanel, new Vector3(1, 1, 1), 0.1f);
        UpdateEquipedPanel();
        UpdateDescriptionpanel(item);
    }

    private void UpdateEquipedPanel()
    {
        LeanTween.scale(equipedPanel, new Vector3(1, 1, 1), 0.1f);
        if(PlayerEquipment.instance.helmet.name != "Item nulo")
        {
            helmetEquipedText.text = $"Capacete: {PlayerEquipment.instance.helmet.name}\n Vida: {PlayerEquipment.instance.helmet.health} | Ataque: {PlayerEquipment.instance.helmet.damage} | Defesa: {PlayerEquipment.instance.helmet.defense} | Veloc.: {PlayerEquipment.instance.helmet.speed}";
        }
        else
        {
            helmetEquipedText.text = "Capacete: --";
        }

        if (PlayerEquipment.instance.armor.name != "Item nulo")
        {
            armorEquipedText.text = $"Armadura: {PlayerEquipment.instance.armor.name}\n Vida: {PlayerEquipment.instance.armor.health} | Ataque: {PlayerEquipment.instance.armor.damage} | Defesa: {PlayerEquipment.instance.armor.defense} | Veloc.: {PlayerEquipment.instance.armor.speed}";
        }
        else
        {
            armorEquipedText.text = "Armadura: --";
        }

        if (PlayerEquipment.instance.legs.name != "Item nulo")
        {
            legsEquipedText.text = $"Calça: {PlayerEquipment.instance.legs.name}\n Vida: {PlayerEquipment.instance.legs.health} | Ataque: {PlayerEquipment.instance.legs.damage} | Defesa: {PlayerEquipment.instance.legs.defense} | Veloc.: {PlayerEquipment.instance.legs.speed}";
        }
        else
        {
            legsEquipedText.text = "Calça: --";
        }

        if (PlayerEquipment.instance.weapon.name != "Item nulo")
        {
            weaponEquipedText.text = $"Arma: {PlayerEquipment.instance.weapon.name}\n Vida: {PlayerEquipment.instance.weapon.health} | Ataque: {PlayerEquipment.instance.weapon.damage} | Defesa: {PlayerEquipment.instance.weapon.defense} | Veloc.: {PlayerEquipment.instance.weapon.speed}";
        }
        else
        {
            weaponEquipedText.text = "Arma: --";
        }
    }

    private void UpdateDescriptionpanel(Item item)
    {
        descriptionText.text = $"{item.name} \n {item.description}";
        if (item is Equip)
        {
            Equip equip = item as Equip;
            inventory_SelectedEquip = equip;
            descriptionStatusText.text = $"Status \nVida: {equip.health} \nAtaque: {equip.damage} \nDefesa: {equip.defense} \nVelocidade: {equip.speed}";
            equipButton.enabled = true;
            equipButtonText.text = "Equipar";
        }
        else
        {
            descriptionStatusText.text = $"Status \nVida: -- \nAtaque: -- \nDefesa: -- \nVelocidade: --";
            equipButton.enabled = false;
            equipButtonText.text = "";
        }
    }
    public void OpenSettings()
    {
        if (settingsPanelIsOpen)
        {
            CloseOpenedPanels();
            return;
        }
        CloseOpenedPanels();
        settingsPanelIsOpen = true;
        LeanTween.scale(settingsPanel, new Vector3(1, 1, 1), 0.1f);
    }

    public void Map_()
    {

    }

    public void Profile_()
    {

    }

    public void Inventory_EquipButton()
    {
        if (PlayerEquipment.instance.EquipToPlayer(inventory_SelectedEquip))
        {
            LoadInventory();
            UpdateEquipedPanel();
        }   
    }

    public void Settings_sound()
    {
        if (soundIsOn)
        {
            soundIsOn = false;
            soundImage.sprite = noSprite;
        }
        else
        {
            soundIsOn = true;
            soundImage.sprite = yesSprite;
        }

    }
    public void Settings_music()
    {
        if (musicIsOn)
        {
            musicIsOn = false;
            musicImage.sprite = noSprite;
        }
        else
        {
            musicIsOn = true;
            musicImage.sprite = yesSprite;
        }
    }
    public void Settings_effects()
    {
        if (effectsIsOn)
        {
            effectsIsOn = false;
            effectsImage.sprite = noSprite;
        }
        else
        {
            effectsIsOn = true;
            effectsImage.sprite = yesSprite;
        }
    }
}
