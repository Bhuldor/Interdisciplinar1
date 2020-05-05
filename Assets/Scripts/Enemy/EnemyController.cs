using UnityEngine;

public class EnemyController : MonoBehaviour{

    [Header("Settings")]
    public float moveSpeed = 2.5f;
    public PlayerHealthManager player;
    public int enemyThreat;

    //Privates
    private Rigidbody mRigidbody;


    void Start(){
        mRigidbody = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerHealthManager>();
    }
   
    void Update(){
        transform.LookAt(player.transform.position);
    }

    private void FixedUpdate(){
        mRigidbody.velocity = transform.forward * moveSpeed;
    }
}
