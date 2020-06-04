using UnityEngine;

public class EnemyHealthManager : MonoBehaviour{

    [Header("Settings")]
    public int health;

    //Privates
    private int currentHealth;
    private int maxHealth;

    void Start(){
        currentHealth = health;
        maxHealth = health;
    }
   
    void Update(){
        if (currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage){
        currentHealth -= damage;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
