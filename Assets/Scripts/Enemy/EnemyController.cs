using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour{

    [Header("Settings")]
    public float moveSpeed = 2.5f;
    public PlayerHealthManager player;
    public int enemyThreat;
    public float distanceToChase;    

    public Transform initTransform;
    private Transform target;

    private NavMeshAgent navMeshAgent;

    //Privates
    private Rigidbody mRigidbody;


    void Start(){        
        mRigidbody = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerHealthManager>();
        navMeshAgent = FindObjectOfType<NavMeshAgent>();

        navMeshAgent.enabled = true;        
    }
   
    private void FixedUpdate(){
        //Procura o player no perimetro
        //Se encontrar, vai até ele
        //Se não achar, volta pra posição inicial

        target = player.transform;

        if (Vector3.Distance(transform.position, target.position) < distanceToChase){
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }else{
            transform.LookAt(initTransform.position);
            transform.position = Vector3.MoveTowards(transform.position, initTransform.position, moveSpeed * Time.deltaTime);
        }
        //mRigidbody.velocity = transform.forward * moveSpeed;
    }
}
