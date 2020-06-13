using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour{

    [Header("Settings")]
    public int health;

    //Privates
    private int currentHealth;
    private int maxHealth;

    void Start(){        
        currentHealth = health;
        maxHealth = health;        
        //SetMaxHealth(maxHealth);
        //Sethealth(currentHealth);
    }
   
    void Update(){
        if (currentHealth <= 0){
            //StartCoroutine(HideHealthBar(2));
            Destroy(gameObject);            
        }
    }

    public void HurtEnemy(int damage){
        //healthBar.SetActive(true);
        currentHealth -= damage;
        //StartCoroutine(HideHealthBar(2));
    }

    public int GetMaxHealth(){
        return maxHealth;
    }
    
    public int GetCurrentHealth(){
        return currentHealth;
    }
}
