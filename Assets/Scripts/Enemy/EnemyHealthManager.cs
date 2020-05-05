using UnityEngine;

public class EnemyHealthManager : MonoBehaviour{

    [Header("Settings")]
    public int health;

    //Privates
    private int currentHealth;

    void Start(){
        currentHealth = health;
    }
   
    void Update(){
        if (currentHealth <= 0){
            Debug.Log("Death Enemy");
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage){
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }
}
