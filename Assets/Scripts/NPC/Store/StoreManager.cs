using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    Item[][] inventoryItens;
    [SerializeField] private Font pixelFont;

    public GameObject storeScrollPanel;
    public GameObject storePanel;
    public Button buyButton;
    public Text itemName;
    public Text itemDescription;
    public Text itemStatus;
    public Text itemStatus2;
    public Text itemPrice1;
    public Text itemPrice2;

    public VerifyEquipmentPower verifyEquip;

    public GameObject cantBuyMessage;


    private bool canBuy = false;
    private int selectedItem = 0;

    private const int itemQuantity = 18;
    public void Awake()
    {
        inventoryItens = new Item[itemQuantity][] { new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3], new Item[3] };
        GameManager.onInventoryLoaded += StoreInventory;
    }

    public void Start()
    {
        DialogueManager.onChatFinished += displayItens;
    }

    public void StoreInventory()
    {

        #region Itens declaration

        Item item1 = new Item();
        Item item1_price1 = new Item();
        Item item1_price2 = new Item();

        Item item2 = new Item();
        Item item2_price1 = new Item();
        Item item2_price2 = new Item();

        Item item3 = new Item();
        Item item3_price1 = new Item();
        Item item3_price2 = new Item();

        Item item4 = new Item();
        Item item4_price1 = new Item();
        Item item4_price2 = new Item();

        Item item5 = new Item();
        Item item5_price1 = new Item();
        Item item5_price2 = new Item();

        Item item6 = new Item();
        Item item6_price1 = new Item();
        Item item6_price2 = new Item();

        Item item7 = new Item();
        Item item7_price1 = new Item();
        Item item7_price2 = new Item();

        Item item8 = new Item();
        Item item8_price1 = new Item();
        Item item8_price2 = new Item();

        Item item9 = new Item();
        Item item9_price1 = new Item();
        Item item9_price2 = new Item();

        Item item10 = new Item();
        Item item10_price1 = new Item();
        Item item10_price2 = new Item();

        Item item11 = new Item();
        Item item11_price1 = new Item();
        Item item11_price2 = new Item();

        Item item12 = new Item();
        Item item12_price1 = new Item();
        Item item12_price2 = new Item();

        Item item13 = new Item();
        Item item13_price1 = new Item();
        Item item13_price2 = new Item();

        Item item14 = new Item();
        Item item14_price1 = new Item();
        Item item14_price2 = new Item();

        Item item15 = new Item();
        Item item15_price1 = new Item();
        Item item15_price2 = new Item();

        Item item16 = new Item();
        Item item16_price1 = new Item();
        Item item16_price2 = new Item();

        Item item17 = new Item();
        Item item17_price1 = new Item();
        Item item17_price2 = new Item();

        Item item18 = new Item();
        Item item18_price1 = new Item();
        Item item18_price2 = new Item();

        #endregion
        switch (GameManager.bossesDefeated)
        {
            case 0:
                #region case 0
                #region Cloning
                //Preços:
                // ID 1: Metal
                // ID 2: Pedras Preciosas
                // ID 3: Tecido
                item1.Clone(Inventory.instance.GetItemByID(4));
                item1_price1.Clone(Inventory.instance.GetItemByID(1));
                item1_price2.Clone(Inventory.instance.GetItemByID(2));

                item2.Clone(Inventory.instance.GetItemByID(9));
                item2_price1.Clone(Inventory.instance.GetItemByID(1));
                item2_price2.Clone(Inventory.instance.GetItemByID(2));

                item3.Clone(Inventory.instance.GetItemByID(14));
                item3_price1.Clone(Inventory.instance.GetItemByID(1));
                item3_price2.Clone(Inventory.instance.GetItemByID(2));

                item4.Clone(Inventory.instance.GetItemByID(19));
                item4_price1.Clone(Inventory.instance.GetItemByID(1));
                item4_price2.Clone(Inventory.instance.GetItemByID(3));

                item5.Clone(Inventory.instance.GetItemByID(23));
                item5_price1.Clone(Inventory.instance.GetItemByID(1));
                item5_price2.Clone(Inventory.instance.GetItemByID(3));

                item6.Clone(Inventory.instance.GetItemByID(27));
                item6_price1.Clone(Inventory.instance.GetItemByID(1));
                item6_price2.Clone(Inventory.instance.GetItemByID(3));

                item7.Clone(Inventory.instance.GetItemByID(31));
                item7_price1.Clone(Inventory.instance.GetItemByID(1));
                item7_price2.Clone(Inventory.instance.GetItemByID(3));

                item8.Clone(Inventory.instance.GetItemByID(35));
                item8_price1.Clone(Inventory.instance.GetItemByID(1));
                item8_price2.Clone(Inventory.instance.GetItemByID(3));

                item9.Clone(Inventory.instance.GetItemByID(39));
                item9_price1.Clone(Inventory.instance.GetItemByID(1));
                item9_price2.Clone(Inventory.instance.GetItemByID(3));

                item10.Clone(Inventory.instance.GetItemByID(43));
                item10_price1.Clone(Inventory.instance.GetItemByID(1));
                item10_price2.Clone(Inventory.instance.GetItemByID(3));

                item11.Clone(Inventory.instance.GetItemByID(47));
                item11_price1.Clone(Inventory.instance.GetItemByID(1));
                item11_price2.Clone(Inventory.instance.GetItemByID(3));

                item12.Clone(Inventory.instance.GetItemByID(51));
                item12_price1.Clone(Inventory.instance.GetItemByID(1));
                item12_price2.Clone(Inventory.instance.GetItemByID(3));

                item13.Clone(Inventory.instance.GetItemByID(55));
                item13_price1.Clone(Inventory.instance.GetItemByID(1));
                item13_price2.Clone(Inventory.instance.GetItemByID(3));

                item14.Clone(Inventory.instance.GetItemByID(59));
                item14_price1.Clone(Inventory.instance.GetItemByID(1));
                item14_price2.Clone(Inventory.instance.GetItemByID(3));

                item15.Clone(Inventory.instance.GetItemByID(63));
                item15_price1.Clone(Inventory.instance.GetItemByID(1));
                item15_price2.Clone(Inventory.instance.GetItemByID(3));

                item16.Clone(Inventory.instance.GetItemByID(67));
                item16_price1.Clone(Inventory.instance.GetItemByID(1));
                item16_price2.Clone(Inventory.instance.GetItemByID(3));

                item17.Clone(Inventory.instance.GetItemByID(68));
                item17_price1.Clone(Inventory.instance.GetItemByID(1));
                item17_price2.Clone(Inventory.instance.GetItemByID(3));

                item18.Clone(Inventory.instance.GetItemByID(69));
                item18_price1.Clone(Inventory.instance.GetItemByID(1));
                item18_price2.Clone(Inventory.instance.GetItemByID(3));

                #endregion

                inventoryItens[0][0] = item1;
                inventoryItens[0][0].quantity = 1;
                    inventoryItens[0][1] = item1_price1; // Preço 1
                    inventoryItens[0][1].quantity = 10; // Quantidade necessaria
                    inventoryItens[0][2] = item1_price2; // Preço 2
                    inventoryItens[0][2].quantity = 40;
                              

                inventoryItens[1][0] = item2; //Item 2
                inventoryItens[1][0].quantity = 1;
                    inventoryItens[1][1] = item2_price1;
                    inventoryItens[1][1].quantity = 10;
                    inventoryItens[1][2] = item2_price2;
                    inventoryItens[1][2].quantity = 40;


                inventoryItens[2][0] = item3; //Item 3
                inventoryItens[2][0].quantity = 1;
                    inventoryItens[2][1] = item3_price1;
                    inventoryItens[2][1].quantity = 10;
                    inventoryItens[2][2] = item3_price2;
                    inventoryItens[2][2].quantity = 40;

                inventoryItens[3][0] = item4; //Item 4
                inventoryItens[3][0].quantity = 1;
                    inventoryItens[3][1] = item4_price1;
                    inventoryItens[3][1].quantity = 25;
                    inventoryItens[3][2] = item4_price2;
                    inventoryItens[3][2].quantity = 10;

                inventoryItens[4][0] = item5;
                inventoryItens[4][0].quantity = 1;
                inventoryItens[4][1] = item5_price1;
                inventoryItens[4][1].quantity = 25;
                inventoryItens[4][2] = item5_price2;
                inventoryItens[4][2].quantity = 10;

                inventoryItens[5][0] = item6; 
                inventoryItens[5][0].quantity = 1;
                inventoryItens[5][1] = item6_price1;
                inventoryItens[5][1].quantity = 25;
                inventoryItens[5][2] = item6_price2;
                inventoryItens[5][2].quantity = 10;

                inventoryItens[6][0] = item7; 
                inventoryItens[6][0].quantity = 1;
                inventoryItens[6][1] = item7_price1;
                inventoryItens[6][1].quantity = 25;
                inventoryItens[6][2] = item7_price2;
                inventoryItens[6][2].quantity = 10;

                inventoryItens[7][0] = item8; 
                inventoryItens[7][0].quantity = 1;
                inventoryItens[7][1] = item8_price1;
                inventoryItens[7][1].quantity = 25;
                inventoryItens[7][2] = item8_price2;
                inventoryItens[7][2].quantity = 10;

                inventoryItens[8][0] = item9; 
                inventoryItens[8][0].quantity = 1;
                inventoryItens[8][1] = item9_price1;
                inventoryItens[8][1].quantity = 25;
                inventoryItens[8][2] = item9_price2;
                inventoryItens[8][2].quantity = 10;

                inventoryItens[9][0] = item10; 
                inventoryItens[9][0].quantity = 1;
                inventoryItens[9][1] = item10_price1;
                inventoryItens[9][1].quantity = 25;
                inventoryItens[9][2] = item10_price2;
                inventoryItens[9][2].quantity = 10;

                inventoryItens[10][0] = item11; 
                inventoryItens[10][0].quantity = 1;
                inventoryItens[10][1] = item11_price1;
                inventoryItens[10][1].quantity = 25;
                inventoryItens[10][2] = item11_price2;
                inventoryItens[10][2].quantity = 10;

                inventoryItens[11][0] = item12; 
                inventoryItens[11][0].quantity = 1;
                inventoryItens[11][1] = item12_price1;
                inventoryItens[11][1].quantity = 25;
                inventoryItens[11][2] = item12_price2;
                inventoryItens[11][2].quantity = 10;

                inventoryItens[12][0] = item13;
                inventoryItens[12][0].quantity = 1;
                inventoryItens[12][1] = item13_price1;
                inventoryItens[12][1].quantity = 25;
                inventoryItens[12][2] = item13_price2;
                inventoryItens[12][2].quantity = 10;

                inventoryItens[13][0] = item14; 
                inventoryItens[13][0].quantity = 1;
                inventoryItens[13][1] = item14_price1;
                inventoryItens[13][1].quantity = 25;
                inventoryItens[13][2] = item14_price2;
                inventoryItens[13][2].quantity = 10;

                inventoryItens[14][0] = item15; 
                inventoryItens[14][0].quantity = 1;
                inventoryItens[14][1] = item15_price1;
                inventoryItens[14][1].quantity = 25;
                inventoryItens[14][2] = item15_price2;
                inventoryItens[14][2].quantity = 10;
            
                inventoryItens[15][0] = item16; 
                inventoryItens[15][0].quantity = 1;
                inventoryItens[15][1] = item16_price1;
                inventoryItens[15][1].quantity = 25;
                inventoryItens[15][2] = item16_price2;
                inventoryItens[15][2].quantity = 10;

                inventoryItens[16][0] = item17; 
                inventoryItens[16][0].quantity = 1;
                inventoryItens[16][1] = item17_price1;
                inventoryItens[16][1].quantity = 25;
                inventoryItens[16][2] = item17_price2;
                inventoryItens[16][2].quantity = 10;

                inventoryItens[17][0] = item18; 
                inventoryItens[17][0].quantity = 1;
                inventoryItens[17][1] = item18_price1;
                inventoryItens[17][1].quantity = 25;
                inventoryItens[17][2] = item18_price2;
                inventoryItens[17][2].quantity = 10;
            break;
            #endregion
            case 1:
                #region case 1
                #region Cloning
                //Preços:
                // ID 1: Metal
                // ID 2: Pedras Preciosas
                // ID 3: Tecido
                item1.Clone(Inventory.instance.GetItemByID(5));
                item1_price1.Clone(Inventory.instance.GetItemByID(1));
                item1_price2.Clone(Inventory.instance.GetItemByID(2));

                item2.Clone(Inventory.instance.GetItemByID(10));
                item2_price1.Clone(Inventory.instance.GetItemByID(1));
                item2_price2.Clone(Inventory.instance.GetItemByID(2));

                item3.Clone(Inventory.instance.GetItemByID(15));
                item3_price1.Clone(Inventory.instance.GetItemByID(1));
                item3_price2.Clone(Inventory.instance.GetItemByID(2));

                item4.Clone(Inventory.instance.GetItemByID(20));
                item4_price1.Clone(Inventory.instance.GetItemByID(1));
                item4_price2.Clone(Inventory.instance.GetItemByID(3));

                item5.Clone(Inventory.instance.GetItemByID(24));
                item5_price1.Clone(Inventory.instance.GetItemByID(1));
                item5_price2.Clone(Inventory.instance.GetItemByID(3));

                item6.Clone(Inventory.instance.GetItemByID(28));
                item6_price1.Clone(Inventory.instance.GetItemByID(1));
                item6_price2.Clone(Inventory.instance.GetItemByID(3));

                item7.Clone(Inventory.instance.GetItemByID(32));
                item7_price1.Clone(Inventory.instance.GetItemByID(1));
                item7_price2.Clone(Inventory.instance.GetItemByID(3));

                item8.Clone(Inventory.instance.GetItemByID(36));
                item8_price1.Clone(Inventory.instance.GetItemByID(1));
                item8_price2.Clone(Inventory.instance.GetItemByID(3));

                item9.Clone(Inventory.instance.GetItemByID(40));
                item9_price1.Clone(Inventory.instance.GetItemByID(1));
                item9_price2.Clone(Inventory.instance.GetItemByID(3));

                item10.Clone(Inventory.instance.GetItemByID(44));
                item10_price1.Clone(Inventory.instance.GetItemByID(1));
                item10_price2.Clone(Inventory.instance.GetItemByID(3));

                item11.Clone(Inventory.instance.GetItemByID(48));
                item11_price1.Clone(Inventory.instance.GetItemByID(1));
                item11_price2.Clone(Inventory.instance.GetItemByID(3));

                item12.Clone(Inventory.instance.GetItemByID(52));
                item12_price1.Clone(Inventory.instance.GetItemByID(1));
                item12_price2.Clone(Inventory.instance.GetItemByID(3));

                item13.Clone(Inventory.instance.GetItemByID(56));
                item13_price1.Clone(Inventory.instance.GetItemByID(1));
                item13_price2.Clone(Inventory.instance.GetItemByID(3));

                item14.Clone(Inventory.instance.GetItemByID(60));
                item14_price1.Clone(Inventory.instance.GetItemByID(1));
                item14_price2.Clone(Inventory.instance.GetItemByID(3));

                item15.Clone(Inventory.instance.GetItemByID(64));
                item15_price1.Clone(Inventory.instance.GetItemByID(1));
                item15_price2.Clone(Inventory.instance.GetItemByID(3));

                item16.Clone(Inventory.instance.GetItemByID(70));
                item16_price1.Clone(Inventory.instance.GetItemByID(1));
                item16_price2.Clone(Inventory.instance.GetItemByID(3));

                item17.Clone(Inventory.instance.GetItemByID(74));
                item17_price1.Clone(Inventory.instance.GetItemByID(1));
                item17_price2.Clone(Inventory.instance.GetItemByID(3));

                item18.Clone(Inventory.instance.GetItemByID(78));
                item18_price1.Clone(Inventory.instance.GetItemByID(1));
                item18_price2.Clone(Inventory.instance.GetItemByID(3));

                #endregion

                inventoryItens[0][0] = item1;
                inventoryItens[0][0].quantity = 1;
                inventoryItens[0][1] = item1_price1; // Preço 1
                inventoryItens[0][1].quantity = 25; // Quantidade necessaria
                inventoryItens[0][2] = item1_price2; // Preço 2
                inventoryItens[0][2].quantity = 75;


                inventoryItens[1][0] = item2; //Item 2
                inventoryItens[1][0].quantity = 1;
                inventoryItens[1][1] = item2_price1;
                inventoryItens[1][1].quantity = 25;
                inventoryItens[1][2] = item2_price2;
                inventoryItens[1][2].quantity = 75;


                inventoryItens[2][0] = item3; //Item 3
                inventoryItens[2][0].quantity = 1;
                inventoryItens[2][1] = item3_price1;
                inventoryItens[2][1].quantity = 25;
                inventoryItens[2][2] = item3_price2;
                inventoryItens[2][2].quantity = 75;

                inventoryItens[3][0] = item4; //Item 4
                inventoryItens[3][0].quantity = 1;
                inventoryItens[3][1] = item4_price1;
                inventoryItens[3][1].quantity = 40;
                inventoryItens[3][2] = item4_price2;
                inventoryItens[3][2].quantity = 25;

                inventoryItens[4][0] = item5;
                inventoryItens[4][0].quantity = 1;
                inventoryItens[4][1] = item5_price1;
                inventoryItens[4][1].quantity = 40;
                inventoryItens[4][2] = item5_price2;
                inventoryItens[4][2].quantity = 25;

                inventoryItens[5][0] = item6;
                inventoryItens[5][0].quantity = 1;
                inventoryItens[5][1] = item6_price1;
                inventoryItens[5][1].quantity = 40;
                inventoryItens[5][2] = item6_price2;
                inventoryItens[5][2].quantity = 25;

                inventoryItens[6][0] = item7;
                inventoryItens[6][0].quantity = 1;
                inventoryItens[6][1] = item7_price1;
                inventoryItens[6][1].quantity = 40;
                inventoryItens[6][2] = item7_price2;
                inventoryItens[6][2].quantity = 25;

                inventoryItens[7][0] = item8;
                inventoryItens[7][0].quantity = 1;
                inventoryItens[7][1] = item8_price1;
                inventoryItens[7][1].quantity = 40;
                inventoryItens[7][2] = item8_price2;
                inventoryItens[7][2].quantity = 25;

                inventoryItens[8][0] = item9;
                inventoryItens[8][0].quantity = 1;
                inventoryItens[8][1] = item9_price1;
                inventoryItens[8][1].quantity = 40;
                inventoryItens[8][2] = item9_price2;
                inventoryItens[8][2].quantity = 25;

                inventoryItens[9][0] = item10;
                inventoryItens[9][0].quantity = 1;
                inventoryItens[9][1] = item10_price1;
                inventoryItens[9][1].quantity = 40;
                inventoryItens[9][2] = item10_price2;
                inventoryItens[9][2].quantity = 25;

                inventoryItens[10][0] = item11;
                inventoryItens[10][0].quantity = 1;
                inventoryItens[10][1] = item11_price1;
                inventoryItens[10][1].quantity = 40;
                inventoryItens[10][2] = item11_price2;
                inventoryItens[10][2].quantity = 25;

                inventoryItens[11][0] = item12;
                inventoryItens[11][0].quantity = 1;
                inventoryItens[11][1] = item12_price1;
                inventoryItens[11][1].quantity = 40;
                inventoryItens[11][2] = item12_price2;
                inventoryItens[11][2].quantity = 25;

                inventoryItens[12][0] = item13;
                inventoryItens[12][0].quantity = 1;
                inventoryItens[12][1] = item13_price1;
                inventoryItens[12][1].quantity = 40;
                inventoryItens[12][2] = item13_price2;
                inventoryItens[12][2].quantity = 25;

                inventoryItens[13][0] = item14;
                inventoryItens[13][0].quantity = 1;
                inventoryItens[13][1] = item14_price1;
                inventoryItens[13][1].quantity = 40;
                inventoryItens[13][2] = item14_price2;
                inventoryItens[13][2].quantity = 25;

                inventoryItens[14][0] = item15;
                inventoryItens[14][0].quantity = 1;
                inventoryItens[14][1] = item15_price1;
                inventoryItens[14][1].quantity = 40;
                inventoryItens[14][2] = item15_price2;
                inventoryItens[14][2].quantity = 25;

                inventoryItens[15][0] = item16;
                inventoryItens[15][0].quantity = 1;
                inventoryItens[15][1] = item16_price1;
                inventoryItens[15][1].quantity = 40;
                inventoryItens[15][2] = item16_price2;
                inventoryItens[15][2].quantity = 25;

                inventoryItens[16][0] = item17;
                inventoryItens[16][0].quantity = 1;
                inventoryItens[16][1] = item17_price1;
                inventoryItens[16][1].quantity = 40;
                inventoryItens[16][2] = item17_price2;
                inventoryItens[16][2].quantity = 25;

                inventoryItens[17][0] = item18;
                inventoryItens[17][0].quantity = 1;
                inventoryItens[17][1] = item18_price1;
                inventoryItens[17][1].quantity = 40;
                inventoryItens[17][2] = item18_price2;
                inventoryItens[17][2].quantity = 25;
                break;
            #endregion
            case 2:
                #region case 2
                #region Cloning
                //Preços:
                // ID 1: Metal
                // ID 2: Pedras Preciosas
                // ID 3: Tecido
                item1.Clone(Inventory.instance.GetItemByID(6));
                item1_price1.Clone(Inventory.instance.GetItemByID(1));
                item1_price2.Clone(Inventory.instance.GetItemByID(2));

                item2.Clone(Inventory.instance.GetItemByID(11));
                item2_price1.Clone(Inventory.instance.GetItemByID(1));
                item2_price2.Clone(Inventory.instance.GetItemByID(2));

                item3.Clone(Inventory.instance.GetItemByID(16));
                item3_price1.Clone(Inventory.instance.GetItemByID(1));
                item3_price2.Clone(Inventory.instance.GetItemByID(2));

                item4.Clone(Inventory.instance.GetItemByID(21));
                item4_price1.Clone(Inventory.instance.GetItemByID(1));
                item4_price2.Clone(Inventory.instance.GetItemByID(3));

                item5.Clone(Inventory.instance.GetItemByID(25));
                item5_price1.Clone(Inventory.instance.GetItemByID(1));
                item5_price2.Clone(Inventory.instance.GetItemByID(3));

                item6.Clone(Inventory.instance.GetItemByID(29));
                item6_price1.Clone(Inventory.instance.GetItemByID(1));
                item6_price2.Clone(Inventory.instance.GetItemByID(3));

                item7.Clone(Inventory.instance.GetItemByID(33));
                item7_price1.Clone(Inventory.instance.GetItemByID(1));
                item7_price2.Clone(Inventory.instance.GetItemByID(3));

                item8.Clone(Inventory.instance.GetItemByID(37));
                item8_price1.Clone(Inventory.instance.GetItemByID(1));
                item8_price2.Clone(Inventory.instance.GetItemByID(3));

                item9.Clone(Inventory.instance.GetItemByID(41));
                item9_price1.Clone(Inventory.instance.GetItemByID(1));
                item9_price2.Clone(Inventory.instance.GetItemByID(3));

                item10.Clone(Inventory.instance.GetItemByID(45));
                item10_price1.Clone(Inventory.instance.GetItemByID(1));
                item10_price2.Clone(Inventory.instance.GetItemByID(3));

                item11.Clone(Inventory.instance.GetItemByID(49));
                item11_price1.Clone(Inventory.instance.GetItemByID(1));
                item11_price2.Clone(Inventory.instance.GetItemByID(3));

                item12.Clone(Inventory.instance.GetItemByID(53));
                item12_price1.Clone(Inventory.instance.GetItemByID(1));
                item12_price2.Clone(Inventory.instance.GetItemByID(3));

                item13.Clone(Inventory.instance.GetItemByID(57));
                item13_price1.Clone(Inventory.instance.GetItemByID(1));
                item13_price2.Clone(Inventory.instance.GetItemByID(3));

                item14.Clone(Inventory.instance.GetItemByID(61));
                item14_price1.Clone(Inventory.instance.GetItemByID(1));
                item14_price2.Clone(Inventory.instance.GetItemByID(3));

                item15.Clone(Inventory.instance.GetItemByID(65));
                item15_price1.Clone(Inventory.instance.GetItemByID(1));
                item15_price2.Clone(Inventory.instance.GetItemByID(3));

                item16.Clone(Inventory.instance.GetItemByID(72));
                item16_price1.Clone(Inventory.instance.GetItemByID(1));
                item16_price2.Clone(Inventory.instance.GetItemByID(3));

                item17.Clone(Inventory.instance.GetItemByID(76));
                item17_price1.Clone(Inventory.instance.GetItemByID(1));
                item17_price2.Clone(Inventory.instance.GetItemByID(3));

                item18.Clone(Inventory.instance.GetItemByID(80));
                item18_price1.Clone(Inventory.instance.GetItemByID(1));
                item18_price2.Clone(Inventory.instance.GetItemByID(3));

                #endregion

                inventoryItens[0][0] = item1;
                inventoryItens[0][0].quantity = 1;
                inventoryItens[0][1] = item1_price1; // Preço 1
                inventoryItens[0][1].quantity = 40; // Quantidade necessaria
                inventoryItens[0][2] = item1_price2; // Preço 2
                inventoryItens[0][2].quantity = 110;


                inventoryItens[1][0] = item2; //Item 2
                inventoryItens[1][0].quantity = 1;
                inventoryItens[1][1] = item2_price1;
                inventoryItens[1][1].quantity = 40;
                inventoryItens[1][2] = item2_price2;
                inventoryItens[1][2].quantity = 110;


                inventoryItens[2][0] = item3; //Item 3
                inventoryItens[2][0].quantity = 1;
                inventoryItens[2][1] = item3_price1;
                inventoryItens[2][1].quantity = 40;
                inventoryItens[2][2] = item3_price2;
                inventoryItens[2][2].quantity = 110;

                inventoryItens[3][0] = item4; //Item 4
                inventoryItens[3][0].quantity = 1;
                inventoryItens[3][1] = item4_price1;
                inventoryItens[3][1].quantity = 75;
                inventoryItens[3][2] = item4_price2;
                inventoryItens[3][2].quantity = 60;

                inventoryItens[4][0] = item5;
                inventoryItens[4][0].quantity = 1;
                inventoryItens[4][1] = item5_price1;
                inventoryItens[4][1].quantity = 75;
                inventoryItens[4][2] = item5_price2;
                inventoryItens[4][2].quantity = 60;

                inventoryItens[5][0] = item6;
                inventoryItens[5][0].quantity = 1;
                inventoryItens[5][1] = item6_price1;
                inventoryItens[5][1].quantity = 75;
                inventoryItens[5][2] = item6_price2;
                inventoryItens[5][2].quantity = 60;

                inventoryItens[6][0] = item7;
                inventoryItens[6][0].quantity = 1;
                inventoryItens[6][1] = item7_price1;
                inventoryItens[6][1].quantity = 75;
                inventoryItens[6][2] = item7_price2;
                inventoryItens[6][2].quantity = 60;

                inventoryItens[7][0] = item8;
                inventoryItens[7][0].quantity = 1;
                inventoryItens[7][1] = item8_price1;
                inventoryItens[7][1].quantity = 75;
                inventoryItens[7][2] = item8_price2;
                inventoryItens[7][2].quantity = 60;

                inventoryItens[8][0] = item9;
                inventoryItens[8][0].quantity = 1;
                inventoryItens[8][1] = item9_price1;
                inventoryItens[8][1].quantity = 75;
                inventoryItens[8][2] = item9_price2;
                inventoryItens[8][2].quantity = 60;

                inventoryItens[9][0] = item10;
                inventoryItens[9][0].quantity = 1;
                inventoryItens[9][1] = item10_price1;
                inventoryItens[9][1].quantity = 75;
                inventoryItens[9][2] = item10_price2;
                inventoryItens[9][2].quantity = 60;

                inventoryItens[10][0] = item11;
                inventoryItens[10][0].quantity = 1;
                inventoryItens[10][1] = item11_price1;
                inventoryItens[10][1].quantity = 75;
                inventoryItens[10][2] = item11_price2;
                inventoryItens[10][2].quantity = 60;

                inventoryItens[11][0] = item12;
                inventoryItens[11][0].quantity = 1;
                inventoryItens[11][1] = item12_price1;
                inventoryItens[11][1].quantity = 75;
                inventoryItens[11][2] = item12_price2;
                inventoryItens[11][2].quantity = 60;

                inventoryItens[12][0] = item13;
                inventoryItens[12][0].quantity = 1;
                inventoryItens[12][1] = item13_price1;
                inventoryItens[12][1].quantity = 75;
                inventoryItens[12][2] = item13_price2;
                inventoryItens[12][2].quantity = 60;

                inventoryItens[13][0] = item14;
                inventoryItens[13][0].quantity = 1;
                inventoryItens[13][1] = item14_price1;
                inventoryItens[13][1].quantity = 75;
                inventoryItens[13][2] = item14_price2;
                inventoryItens[13][2].quantity = 60;

                inventoryItens[14][0] = item15;
                inventoryItens[14][0].quantity = 1;
                inventoryItens[14][1] = item15_price1;
                inventoryItens[14][1].quantity = 75;
                inventoryItens[14][2] = item15_price2;
                inventoryItens[14][2].quantity = 60;

                inventoryItens[15][0] = item16;
                inventoryItens[15][0].quantity = 1;
                inventoryItens[15][1] = item16_price1;
                inventoryItens[15][1].quantity = 75;
                inventoryItens[15][2] = item16_price2;
                inventoryItens[15][2].quantity = 60;

                inventoryItens[16][0] = item17;
                inventoryItens[16][0].quantity = 1;
                inventoryItens[16][1] = item17_price1;
                inventoryItens[16][1].quantity = 75;
                inventoryItens[16][2] = item17_price2;
                inventoryItens[16][2].quantity = 60;

                inventoryItens[17][0] = item18;
                inventoryItens[17][0].quantity = 1;
                inventoryItens[17][1] = item18_price1;
                inventoryItens[17][1].quantity = 75;
                inventoryItens[17][2] = item18_price2;
                inventoryItens[17][2].quantity = 60;
                break;
            #endregion
            case 3:
                #region case 3
                #region Cloning
                //Preços:
                // ID 1: Metal
                // ID 2: Pedras Preciosas
                // ID 3: Tecido
                item1.Clone(Inventory.instance.GetItemByID(8));
                item1_price1.Clone(Inventory.instance.GetItemByID(1));
                item1_price2.Clone(Inventory.instance.GetItemByID(2));

                item2.Clone(Inventory.instance.GetItemByID(13));
                item2_price1.Clone(Inventory.instance.GetItemByID(1));
                item2_price2.Clone(Inventory.instance.GetItemByID(2));

                item3.Clone(Inventory.instance.GetItemByID(18));
                item3_price1.Clone(Inventory.instance.GetItemByID(1));
                item3_price2.Clone(Inventory.instance.GetItemByID(2));

                item4.Clone(Inventory.instance.GetItemByID(22));
                item4_price1.Clone(Inventory.instance.GetItemByID(1));
                item4_price2.Clone(Inventory.instance.GetItemByID(3));

                item5.Clone(Inventory.instance.GetItemByID(26));
                item5_price1.Clone(Inventory.instance.GetItemByID(1));
                item5_price2.Clone(Inventory.instance.GetItemByID(3));

                item6.Clone(Inventory.instance.GetItemByID(30));
                item6_price1.Clone(Inventory.instance.GetItemByID(1));
                item6_price2.Clone(Inventory.instance.GetItemByID(3));

                item7.Clone(Inventory.instance.GetItemByID(34));
                item7_price1.Clone(Inventory.instance.GetItemByID(1));
                item7_price2.Clone(Inventory.instance.GetItemByID(3));

                item8.Clone(Inventory.instance.GetItemByID(38));
                item8_price1.Clone(Inventory.instance.GetItemByID(1));
                item8_price2.Clone(Inventory.instance.GetItemByID(3));

                item9.Clone(Inventory.instance.GetItemByID(42));
                item9_price1.Clone(Inventory.instance.GetItemByID(1));
                item9_price2.Clone(Inventory.instance.GetItemByID(3));

                item10.Clone(Inventory.instance.GetItemByID(46));
                item10_price1.Clone(Inventory.instance.GetItemByID(1));
                item10_price2.Clone(Inventory.instance.GetItemByID(3));

                item11.Clone(Inventory.instance.GetItemByID(50));
                item11_price1.Clone(Inventory.instance.GetItemByID(1));
                item11_price2.Clone(Inventory.instance.GetItemByID(3));

                item12.Clone(Inventory.instance.GetItemByID(54));
                item12_price1.Clone(Inventory.instance.GetItemByID(1));
                item12_price2.Clone(Inventory.instance.GetItemByID(3));

                item13.Clone(Inventory.instance.GetItemByID(58));
                item13_price1.Clone(Inventory.instance.GetItemByID(1));
                item13_price2.Clone(Inventory.instance.GetItemByID(3));

                item14.Clone(Inventory.instance.GetItemByID(62));
                item14_price1.Clone(Inventory.instance.GetItemByID(1));
                item14_price2.Clone(Inventory.instance.GetItemByID(3));

                item15.Clone(Inventory.instance.GetItemByID(66));
                item15_price1.Clone(Inventory.instance.GetItemByID(1));
                item15_price2.Clone(Inventory.instance.GetItemByID(3));

                item16.Clone(Inventory.instance.GetItemByID(77));
                item16_price1.Clone(Inventory.instance.GetItemByID(1));
                item16_price2.Clone(Inventory.instance.GetItemByID(3));

                item17.Clone(Inventory.instance.GetItemByID(79));
                item17_price1.Clone(Inventory.instance.GetItemByID(1));
                item17_price2.Clone(Inventory.instance.GetItemByID(3));

                item18.Clone(Inventory.instance.GetItemByID(81));
                item18_price1.Clone(Inventory.instance.GetItemByID(1));
                item18_price2.Clone(Inventory.instance.GetItemByID(3));

                #endregion

                inventoryItens[0][0] = item1;
                inventoryItens[0][0].quantity = 1;
                inventoryItens[0][1] = item1_price1; // Preço 1
                inventoryItens[0][1].quantity = 75; // Quantidade necessaria
                inventoryItens[0][2] = item1_price2; // Preço 2
                inventoryItens[0][2].quantity = 150;


                inventoryItens[1][0] = item2; //Item 2
                inventoryItens[1][0].quantity = 1;
                inventoryItens[1][1] = item2_price1;
                inventoryItens[1][1].quantity = 75;
                inventoryItens[1][2] = item2_price2;
                inventoryItens[1][2].quantity = 150;


                inventoryItens[2][0] = item3; //Item 3
                inventoryItens[2][0].quantity = 1;
                inventoryItens[2][1] = item3_price1;
                inventoryItens[2][1].quantity = 75;
                inventoryItens[2][2] = item3_price2;
                inventoryItens[2][2].quantity = 150;

                inventoryItens[3][0] = item4; //Item 4
                inventoryItens[3][0].quantity = 1;
                inventoryItens[3][1] = item4_price1;
                inventoryItens[3][1].quantity = 120;
                inventoryItens[3][2] = item4_price2;
                inventoryItens[3][2].quantity = 150;

                inventoryItens[4][0] = item5;
                inventoryItens[4][0].quantity = 1;
                inventoryItens[4][1] = item5_price1;
                inventoryItens[4][1].quantity = 120;
                inventoryItens[4][2] = item5_price2;
                inventoryItens[4][2].quantity = 150;

                inventoryItens[5][0] = item6;
                inventoryItens[5][0].quantity = 1;
                inventoryItens[5][1] = item6_price1;
                inventoryItens[5][1].quantity = 120;
                inventoryItens[5][2] = item6_price2;
                inventoryItens[5][2].quantity = 150;

                inventoryItens[6][0] = item7;
                inventoryItens[6][0].quantity = 1;
                inventoryItens[6][1] = item7_price1;
                inventoryItens[6][1].quantity = 120;
                inventoryItens[6][2] = item7_price2;
                inventoryItens[6][2].quantity = 150;

                inventoryItens[7][0] = item8;
                inventoryItens[7][0].quantity = 1;
                inventoryItens[7][1] = item8_price1;
                inventoryItens[7][1].quantity = 120;
                inventoryItens[7][2] = item8_price2;
                inventoryItens[7][2].quantity = 150;

                inventoryItens[8][0] = item9;
                inventoryItens[8][0].quantity = 1;
                inventoryItens[8][1] = item9_price1;
                inventoryItens[8][1].quantity = 120;
                inventoryItens[8][2] = item9_price2;
                inventoryItens[8][2].quantity = 150;

                inventoryItens[9][0] = item10;
                inventoryItens[9][0].quantity = 1;
                inventoryItens[9][1] = item10_price1;
                inventoryItens[9][1].quantity = 120;
                inventoryItens[9][2] = item10_price2;
                inventoryItens[9][2].quantity = 150;

                inventoryItens[10][0] = item11;
                inventoryItens[10][0].quantity = 1;
                inventoryItens[10][1] = item11_price1;
                inventoryItens[10][1].quantity = 120;
                inventoryItens[10][2] = item11_price2;
                inventoryItens[10][2].quantity = 150;

                inventoryItens[11][0] = item12;
                inventoryItens[11][0].quantity = 1;
                inventoryItens[11][1] = item12_price1;
                inventoryItens[11][1].quantity = 120;
                inventoryItens[11][2] = item12_price2;
                inventoryItens[11][2].quantity = 150;

                inventoryItens[12][0] = item13;
                inventoryItens[12][0].quantity = 1;
                inventoryItens[12][1] = item13_price1;
                inventoryItens[12][1].quantity = 120;
                inventoryItens[12][2] = item13_price2;
                inventoryItens[12][2].quantity = 150;

                inventoryItens[13][0] = item14;
                inventoryItens[13][0].quantity = 1;
                inventoryItens[13][1] = item14_price1;
                inventoryItens[13][1].quantity = 120;
                inventoryItens[13][2] = item14_price2;
                inventoryItens[13][2].quantity = 150;

                inventoryItens[14][0] = item15;
                inventoryItens[14][0].quantity = 1;
                inventoryItens[14][1] = item15_price1;
                inventoryItens[14][1].quantity = 120;
                inventoryItens[14][2] = item15_price2;
                inventoryItens[14][2].quantity = 150;

                inventoryItens[15][0] = item16;
                inventoryItens[15][0].quantity = 1;
                inventoryItens[15][1] = item16_price1;
                inventoryItens[15][1].quantity = 120;
                inventoryItens[15][2] = item16_price2;
                inventoryItens[15][2].quantity = 150;

                inventoryItens[16][0] = item17;
                inventoryItens[16][0].quantity = 1;
                inventoryItens[16][1] = item17_price1;
                inventoryItens[16][1].quantity = 120;
                inventoryItens[16][2] = item17_price2;
                inventoryItens[16][2].quantity = 150;

                inventoryItens[17][0] = item18;
                inventoryItens[17][0].quantity = 1;
                inventoryItens[17][1] = item18_price1;
                inventoryItens[17][1].quantity = 120;
                inventoryItens[17][2] = item18_price2;
                inventoryItens[17][2].quantity = 150;
                break;
                #endregion
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
        for (int item = 0; item < itemQuantity; item++)
        {
            float sizeX = storeScrollPanel.GetComponent<RectTransform>().rect.x;
            if (inventoryItens[item][0] != null)
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
                itemText.fontSize = 60;
                itemText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                itemText.resizeTextForBestFit = true;
                itemText.rectTransform.sizeDelta = new Vector2(10, 100);
                itemText.resizeTextMaxSize = 60;
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
        Item equip = item;
        itemName.text = equip.name;
        itemDescription.text = equip.description;
        itemStatus.text = $" Vida: {equip.health} \n Ataque: {equip.damage} \n Defesa: {equip.defense} \n Velocidade: {equip.speed}";
        itemStatus2.text = $" Resistência a Queimação: {equip.burnResist}%\n Resistência a Veneno: {equip.poisonResist}%\n Resistência a Paralisia: {equip.paralyseResist}%\n Resistência a Medo: {equip.fearResist}%";
        verifyEquip.VerifyEquipPower(equip);
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
        GameManager.onInventoryLoaded -= StoreInventory;
    }

    

   

    
}
