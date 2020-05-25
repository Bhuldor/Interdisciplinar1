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

    void Start(){
        player = GetComponent<PlayerStatus>();
        startingHealth = player.getTotalHP();
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(currentHealth);
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");

        PlayerStatus.OnLevelUp += FullHeal;
    }
   
    void Update(){
        if (currentHealth <= 0){
            gameObject.SetActive(false);
        }

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
        healthBar.Sethealth(currentHealth);
        flashCounter = flashLenght;
        rend.material.SetColor("_Color", Color.white);
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

    private void OnDestroy()
    {
        PlayerStatus.OnLevelUp -= FullHeal;
    }
}
