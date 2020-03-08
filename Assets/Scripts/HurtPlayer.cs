using UnityEngine;

public class HurtPlayer : MonoBehaviour{

    [Header("Settings")]
    public int damageToGive;

    public void OnTriggerEnter(Collider other) { 
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
        }
    }
}
