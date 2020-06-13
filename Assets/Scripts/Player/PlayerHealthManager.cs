using System.Collections;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour{

    [Header("Settings")]
    
    public float flashLenght;
    

    //Privates
    private float currentHealth;
    private float startingHealth;
    private float flashCounter;
    private Renderer rend;
    private Color storedColor;
    [SerializeField] private HealthBar healthBar;
    private PlayerStatus player;
    private BlackOutAnimation fadePanel;
    public bool gameOver = false;

    void Start(){
        fadePanel = GameObject.Find("FadeController").GetComponent<BlackOutAnimation>();
        player = GetComponent<PlayerStatus>();
        startingHealth = player.getTotalHP();
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(currentHealth);
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");

        PlayerStatus.OnLevelUp += FullHeal;
    }
   
    void Update(){

        if (flashCounter > 0){
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0){
                rend.material.SetColor("_Color", storedColor);
            }
        }
        if(player.getTotalHP() != startingHealth)
        {
            startingHealth = player.getTotalHP();
            healthBar.SetMaxHealth(startingHealth);
        }
        if (currentHealth > player.getTotalHP())
            currentHealth = player.getTotalHP();
    }

    public void HurtPlayer(int damageAmount){
        currentHealth -= damageAmount;
        if (currentHealth < 0)
            currentHealth = 0;
        healthBar.Sethealth(currentHealth);
        flashCounter = flashLenght;
        rend.material.SetColor("_Color", Color.white);
        if (currentHealth == 0)
            GameOver();
    }

    public void HealPlayer(float healAmount)
    {
        currentHealth += healAmount;
        healthBar.Sethealth(currentHealth);
    }
    public void FullHeal()
    {
        startingHealth = player.getTotalHP();
        healthBar.SetMaxHealth(startingHealth);
        HealPlayer(player.getTotalHP());
    }

    private void GameOver()
    {
        if (gameOver)
            return;
        //Ativar animação de morrer
        float playerDeathAnimTime = 1f; //Duração da animação
        gameOver = true;
        StartCoroutine(WaitAndCallGameOver(playerDeathAnimTime));
    }

    private IEnumerator WaitAndCallGameOver(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        fadePanel.ExitingSceneAsync("GameOver", WaitTime);
        yield return new WaitForSeconds(WaitTime);
        player.gameObject.transform.position = GameManager.playerStartPosition;
        FullHeal();
        gameOver = false;
    }

    private void OnDestroy()
    {
        PlayerStatus.OnLevelUp -= FullHeal;
    }
}
