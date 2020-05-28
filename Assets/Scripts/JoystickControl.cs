using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class JoystickControl : MonoBehaviour{


    public float speed;
    public FixedJoystick fixedJoystick;
    public ButtonAction basicAttack;
    public ButtonAction specialAttack;
    public ButtonAction skillOne;
    public ButtonAction skillTwo;
    public Rigidbody rb;

    public bool isAxe;
    public bool isSword;
    public bool isDagger;

    public GameObject swordSkill;
    public GameObject axeSkill;
    private GameObject weaponSkill;

    private Animator anim;
    private bool isAttacking = false;

    //Dash
    public float dashSpeed;
    public float startDashTime;
    public TrailRenderer dashTrail;

    private float dashTime;
    private float attackTime;
    private bool dashed = false;
    private bool skillUsed = false;
    private Vector3 direction;

    private void Start(){
        dashTime = startDashTime;
        dashTrail.enabled = false;
        anim = GetComponent<Animator>();
    }

    public void FixedUpdate(){
        direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        rb.velocity = direction;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        rb.constraints &= ~RigidbodyConstraints.FreezePosition;

        if (direction != new Vector3(0, 0, 0)){
            anim.SetFloat("Speed", 1);
            anim.SetBool("Attacking", false);
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        if (dashed){
            if (dashTime <= 0){
                dashTrail.enabled = false;
                dashTime = startDashTime;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.Sleep();
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                Debug.Log("Parou Dash");
                dashed = false;
            }
            else{
                dashTime -= Time.deltaTime;
            }
        }

        //BasicAttack
        if (basicAttack.action()) {            
            anim.SetBool("Attacking", true);
            StartCoroutine(WaitAttackEnd(1f));
        }
        //SpecialAttack
        if (specialAttack.action()){
            anim.SetBool("Attacking", false);
            if (isAxe){
                //Procura por weaponSkill na cena para permitir a ação
                if (GameObject.FindGameObjectsWithTag("WeaponSkill").Length == 0){
                    LifeStealSkill();
                }
            }
            else if (isSword){
                //Procura por weaponSkill na cena para permitir a ação
                if (GameObject.FindGameObjectsWithTag("WeaponSkill").Length == 0){
                    ShieldSkill();
                }
            }else if (isDagger){

                if (!dashed){
                    rb.velocity = (Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal) * dashSpeed;
                    //rb.velocity = Vector3.forward * dashSpeed;
                    dashed = true;
                    dashTrail.enabled = true;
                }
            }
        }

        //SkillOne
        if (skillOne.action()){
            Debug.Log("skillOne");
        }

        //SkillTwo
        if (skillTwo.action()){
            Debug.Log("skillTwo");
        }
    }

    private void ShieldSkill(){
        skillUsed = true;
        weaponSkill = Instantiate(swordSkill, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
        weaponSkill.transform.parent = GameObject.Find("Player").transform;
        Destroy(weaponSkill, 5);
    }
    
    private void LifeStealSkill(){
        skillUsed = true;
        weaponSkill = Instantiate(axeSkill, new Vector3(transform.position.x, transform.position.y, transform.position.z), axeSkill.transform.rotation);
        weaponSkill.transform.parent = GameObject.Find("Player").transform;
        Destroy(weaponSkill, 5);
    }

    IEnumerator WaitAttackEnd(float waitTime){
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Attacking", false);
    }
}