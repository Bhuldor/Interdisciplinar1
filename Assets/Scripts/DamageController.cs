using UnityEngine;

public class DamageController : MonoBehaviour
{
    [Header("Settings")]
    public int damageToGive;
    public string whoToHurt = "Player";

    public void OnTriggerEnter(Collider other){        
        if (other.gameObject.tag == "Weapon" && transform.tag == "Enemy"){
            transform.GetComponent<EnemyHealthManager>().HurtEnemy(other.gameObject.GetComponent<DamageController>().damageToGive);
        }

        if (other.gameObject.tag == whoToHurt)
        {
            switch (whoToHurt)
            {
                case "Player":
                    other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
                    break;
                case "Enemy":
                    Debug.Log(other.gameObject.name);
                    other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                    break;
            }
        }
    }
}
