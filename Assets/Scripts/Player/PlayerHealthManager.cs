using UnityEngine;

public class PlayerHealthManager : MonoBehaviour{

    [Header("Settings")]
    public int startingHealth;
    public float flashLenght;
    public HealthBar healthBar;

    //Privates
    private int currentHealth;
    private float flashCounter;
    private Renderer rend;
    private Color storedColor;

    void Start(){
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
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
    }

    public void HurtPlayer(int damageAmount){
        currentHealth -= damageAmount;
        healthBar.Sethealth(currentHealth);
        flashCounter = flashLenght;
        rend.material.SetColor("_Color", Color.white);
    }
}
