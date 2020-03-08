using UnityEngine;

public class BulletController : MonoBehaviour{

    [Header("Settings")]
    public float moveSpeed;
    public float lifeTime;
    public int damageToGive;

    void Start(){
        
    }
   
    void Update(){
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Destroy(gameObject);
        }
    }
}
