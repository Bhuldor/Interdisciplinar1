using UnityEngine;
using UnityEngine.UI;

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
    public static bool gameSounds = true;
    public static bool gameEffects = true;
    public static bool gameMusics = true;
    public enum Language
    {
        Portuguese,
        English
    }
    public static Language selectedLanguage = Language.Portuguese;

    //Private
    private float positionX = 22;
    private float positionZ = 22;

    private bool gamePaused = false;

    


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
}
