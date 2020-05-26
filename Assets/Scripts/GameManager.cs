using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour{

    [Header("Enemies Prefabs")]
    public int zombieCount;
    public EnemyController zombie;
    public float limitX = 22;
    public float limitZ = 22;
    public float playerSafeSpawnX = 4; 
    public float playerSafeSpawnZ = 4;

    [Header("Menu")]
    public ButtonAction pause;
    public Sprite pauseImg;
    public Sprite playImg;
    public Font defauldFont;

    //Static
    public static int difficultLevel = 1;
    public static int bossesDefeated = 0; //Used by StoreManager
    public static bool gameSounds = true;
    public static bool gameEffects = true;
    public static bool gameMusics = true;
    private static bool gamePaused = false;

    public enum Language
    {
        Portuguese,
        English
    }
    public static Language selectedLanguage = Language.Portuguese;

    public delegate void InventoryLoaded();
    public static event InventoryLoaded onInventoryLoaded;

    //Private
    private float positionX = 22;
    private float positionZ = 22;
    private string json = "";
    
    

    private void Awake()
    {
        StartInventory();
    }


    void Start(){
        Time.timeScale = 1f;

        for (int count = 0; count <= zombieCount; count++){
            do{
                positionX = Random.Range(limitX * (-1), limitX);
            } while (positionX <= playerSafeSpawnX && positionX >= (playerSafeSpawnX*-1));

            do{
                positionZ = Random.Range(limitZ * (-1), limitZ);
            } while (positionZ <= playerSafeSpawnZ && positionZ >= (playerSafeSpawnZ*-1));

            //EnemyController newEnemie = Instantiate(zombie, new Vector3(positionX, zombie.transform.position.y, positionZ), zombie.transform.rotation) as EnemyController;


        }
    }
   
    void Update(){

        /*
        if (gamePaused) {
            if (pause.action()){
                Debug.Log("Play");
                pause.GetComponent<Image>().sprite = pauseImg;
                gamePaused = false;
                Time.timeScale = 1f;
            }
        }else{
            if (pause.action()){
                pause.GetComponent<Image>().sprite = playImg;
                Debug.Log("Pause");
                gamePaused = true;
                Time.timeScale = 0f;
            }
        }
        */
    }

    private void StartInventory()
    {
        if (Inventory.instance != null)
            Debug.LogWarning("Mais de uma instancia de inventario!");
        Inventory.instance = new Inventory();
        string itemListPath = System.IO.Path.Combine(Application.streamingAssetsPath, $"ItemList_{selectedLanguage}.json");
        if (itemListPath.Contains("://") || itemListPath.Contains(":///"))
            StartCoroutine(RequestJson(itemListPath));
        else
        {
            Inventory.instance.ReadJson(System.IO.File.ReadAllText(itemListPath));
            StartPlayerEquipment();
        }
            

        

    }

     private IEnumerator RequestJson(string path)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(path);
        yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError)
            Debug.LogError($"Erro ao tentar abrir arquivo de inventaro {webRequest.error}");
        else
            Inventory.instance.ReadJson(webRequest.downloadHandler.text);
        StartPlayerEquipment();
    }

    private void StartPlayerEquipment()
    {
        if (PlayerEquipment.instance != null)
            Debug.LogWarning("Mais de uma instancia de Player Equipment!");
        PlayerEquipment.instance = new PlayerEquipment();

        StartCoroutine(CallEvent());
    }

    private IEnumerator CallEvent()
    {
        yield return new WaitForSeconds(1f);

        onInventoryLoaded?.Invoke();

    }

    public static void PauseGame()
    {
        if (gamePaused)
        {
            gamePaused = false;
        }
        else
        {
            gamePaused = true;
        }
            
    }
}
