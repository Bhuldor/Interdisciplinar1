using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoitataController : MonoBehaviour
{
    [Header("Prefabs")]
    public BulletController fireball;
    public GameObject minionSecond;
    public GameObject minionThird;

    [Header("Settings")]
    public bool isFiring = false;    
    public float bulletSpeed = 7.5f;
    public float fireRate;
    public Transform firePoint;
    public EnemyHealthManager boitataHealth;
    public AudioSource fireBallSound;

    [Header("Skills Range")]
    public float percentSummon = 0.5f;
    public float summonAmount = 2;
    public float skillsCd = 1f;
    public Transform summonsSpawnOne;
    public Transform summonsSpawnSec;
    public Transform summonsSpawnThi;
    public Transform summonsSpawnFour;

    //Privates
    private float shotCounter;
    private float skillCdCounter = 5;
    private bool canSummon = false;
    private int skill = 2;
    private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!canSummon)
            if (boitataHealth.GetCurrentHealth() / boitataHealth.GetMaxHealth() <= percentSummon)
            {
                canSummon = true;
                skill++;
            }

        skillCdCounter -= Time.deltaTime;
        if (skillCdCounter <= 0)
        {
            switch (Random.Range(0, skill))
            {
                //fireball
                case 0:
                    fireBallSound.Play();
                    anim.SetInteger("skill", 0);
                    shotCounter = fireRate;
                    BulletController newBullet = Instantiate(fireball, firePoint.position, firePoint.rotation) as BulletController;
                    newBullet.moveSpeed = bulletSpeed;                    
                    break;
                //bite
                case 1:
                    anim.SetInteger("skill", 1);
                    break;
                //summon
                case 2:
                    anim.SetInteger("skill", 2);

                    var instanceFirstEnemy = minionSecond;
                    var instanceSecEnemy = minionSecond;
                    var instanceThiEnemy = minionThird;
                    var instanceFouEnemy = minionThird;

                    instanceFirstEnemy.transform.position = summonsSpawnOne.position;
                    instanceFirstEnemy.transform.position = new Vector3(instanceFirstEnemy.transform.position.x, instanceFirstEnemy.transform.position.y, instanceFirstEnemy.transform.position.z);

                    instanceSecEnemy.transform.position = summonsSpawnSec.position;
                    instanceSecEnemy.transform.position = new Vector3(instanceSecEnemy.transform.position.x, instanceSecEnemy.transform.position.y, instanceSecEnemy.transform.position.z);

                    instanceThiEnemy.transform.position = summonsSpawnThi.position;
                    instanceThiEnemy.transform.position = new Vector3(instanceThiEnemy.transform.position.x, instanceThiEnemy.transform.position.y, instanceThiEnemy.transform.position.z);

                    instanceFouEnemy.transform.position = summonsSpawnFour.position;
                    instanceFouEnemy.transform.position = new Vector3(instanceFouEnemy.transform.position.x, instanceFouEnemy.transform.position.y, instanceFouEnemy.transform.position.z);
                    break;
                //bite
                default:
                    break;
            }

            skillCdCounter = 3;
            StartCoroutine(WaitAttackEnd(skillsCd));
            
        }
    }

    IEnumerator WaitAttackEnd(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);        
        anim.SetInteger("skill", -1);
    }
}
