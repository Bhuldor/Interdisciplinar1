using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    private int difficultLevel = 1;
    Item[][] inventoryItens;
    public Font pixelFont;

    public GameObject storeScrollPanel;
    public GameObject storePanel;
    public Button buyButton;
    public Text itemName;
    public Text itemDescription;
    public Text itemStatus;
    public Text itemPrice1;
    public Text itemPrice2;
    public GameObject cantBuyMessage;


    private bool canBuy = false;
    private int selectedItem = 0;
    public void Awake()
    {
        inventoryItens = new Item[3][] { new Item[3], new Item[3], new Item[3]};
    }

    public void Start()
    {
        StoreInventory();
        DialogueManager.onChatFinished += displayItens;
    }

    public void StoreInventory()
    {
        #region Itens declaration

        Equip item1 = new Equip();
        Item item1_price1 = new Item();
        Item item1_price2 = new Item();

        Equip item2 = new Equip();
        Item item2_price1 = new Item();
        Item item2_price2 = new Item();

        Equip item3 = new Equip();
        Item item3_price1 = new Item();
        Item item3_price2 = new Item();

        #endregion
        switch (difficultLevel)
        {
            case 1:
                #region Cloning
                item1.Clone((Equip)Inventory.instance.GetItemByID(7));
                item1_price1.Clone(Inventory.instance.GetItemByID(2));
                item1_price2.Clone(Inventory.instance.GetItemByID(3));

                item2.Clone((Equip)Inventory.instance.GetItemByID(9));
                item2_price1.Clone(Inventory.instance.GetItemByID(1));
                //item2_price2.Clone();

                item3.Clone((Equip)Inventory.instance.GetItemByID(8));
                item3_price1.Clone(Inventory.instance.GetItemByID(4));
                item3_price2.Clone(Inventory.instance.GetItemByID(6));

                #endregion

                inventoryItens[0][0] = item1;
                inventoryItens[0][0].quantity = 1;
                    inventoryItens[0][1] = item1_price1; // Preço 1
                    inventoryItens[0][1].quantity = 1; // Quantidade necessaria
                    inventoryItens[0][2] = item1_price2; // Preço 2
                    inventoryItens[0][2].quantity = 1;
                              

                inventoryItens[1][0] = item2; //Item 2
                inventoryItens[1][0].quantity = 1;
                    inventoryItens[1][1] = item2_price1;
                    inventoryItens[1][1].quantity = 2;


                inventoryItens[2][0] = item3; //Item 3
                inventoryItens[2][0].quantity = 1;
                    inventoryItens[2][1] = item3_price1;
                    inventoryItens[2][1].quantity = 1;
                    inventoryItens[2][2] = item3_price2;
                    inventoryItens[2][2].quantity = 1;

                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }
            
    public void displayItens()
    {
        int count = storeScrollPanel.transform.childCount;
        if (count != 0)
        {
            for (int a = 0; a < count; a++)
            {
                Destroy(storeScrollPanel.transform.GetChild(a).gameObject);
            }
        }
        for (int item = 0; item < 3; item++)
        {
            if(inventoryItens[item][0] != null)
            {
                var i = inventoryItens[item][0];
                var price1 = inventoryItens[item][1];
                var price2 = inventoryItens[item][2];
                var index = item;
                GameObject newItem = new GameObject(i.name);
                var itemText = newItem.AddComponent<Text>();
                var newButton = newItem.AddComponent<Button>();

                itemText.text = $"{i.name}";
                itemText.font = pixelFont;
                itemText.color = Color.black;
                itemText.rectTransform.sizeDelta = new Vector2(170, 35);
                itemText.transform.SetParent(newButton.transform);
                newButton.transform.SetParent(storeScrollPanel.transform);
                newButton.onClick.AddListener(() => ClickOnItem(i, price1, price2, index));

                LeanTween.scale(newItem, new Vector3(1, 1, 1), 0.1f);
                LeanTween.scale(storePanel, new Vector3(1, 1, 1), 0.1f);

                if(index == 0)
                {
                    ClickOnItem(i, price1, price2, index);
                }
            }
        }
    }

    public void ClickOnItem(Item item, Item price1, Item price2, int index)
    {
        selectedItem = index;
        Equip equip = item as Equip;
        itemName.text = equip.name;
        itemDescription.text = equip.description;
        itemStatus.text = $"Vida: {equip.health} \n Ataque: {equip.damage} \n Defesa: {equip.defense} \n Velocidade: {equip.speed}";
        
        var playerHasPrice1 = Inventory.instance.GetQuantity(price1);
        itemPrice1.text = $"{price1.name} x{price1.quantity}";
        if (playerHasPrice1 >= price1.quantity)
        {
            itemPrice1.color = Color.green;
            canBuy = true;
        }
        else
        {
            itemPrice1.color = Color.red;
            canBuy = false;
        }
            

        if (price2 != null)
        {
            var playerHasPrice2 = Inventory.instance.GetQuantity(price2);
            itemPrice2.text = $"{price2.name} x{price2.quantity}";
            if (playerHasPrice2 >= price2.quantity)
                itemPrice2.color = Color.green;
            else
            {
                itemPrice2.color = Color.red;
                canBuy = false;
            }
                
        }
        else
            itemPrice2.text = "";
        cantBuyMessage.SetActive(false);
    }

    public void BuyButton()
    {
        if (canBuy)
        {

            var item = inventoryItens[selectedItem][0];
            Inventory.instance.ObtainDrop(item);
            
            var price1 = inventoryItens[selectedItem][1];
            Inventory.instance.Remove(price1);

            var price2 = inventoryItens[selectedItem][2];
            if (price2 != null)
                Inventory.instance.Remove(price2);

            ClickOnItem(item, price1, price2, selectedItem);
        }
        else
            cantBuyMessage.SetActive(true);

    }

    public void CloseButton()
    {
        LeanTween.scale(storePanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
    }

    private void OnDestroy()
    {
        DialogueManager.onChatFinished -= displayItens;
    }
}
