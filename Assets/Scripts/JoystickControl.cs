using System.Collections;
using System.Collections.Generic;
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
    
    //Dash
    public float dashSpeed;
    public float startDashTime;
    public TrailRenderer dashTrail;

    private float dashTime;
    private bool dashed = false;
    private bool skillUsed = false;
    private Vector3 direction;

    private void Start(){
        dashTime = startDashTime;
        dashTrail.enabled = false;
    }

    public void FixedUpdate(){
        direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.constraints &= ~RigidbodyConstraints.FreezePosition;

        if (direction != new Vector3(0, 0, 0)){
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
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
            Debug.Log("Basic");
        }
        //SpecialAttack
        if (specialAttack.action()){
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
        weaponSkill = Instantiate(swordSkill, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        weaponSkill.transform.parent = GameObject.Find("Player").transform;
        Destroy(weaponSkill, 5);
    }
    
    private void LifeStealSkill(){
        skillUsed = true;
        weaponSkill = Instantiate(axeSkill, new Vector3(transform.position.x, transform.position.y, transform.position.z), axeSkill.transform.rotation);
        weaponSkill.transform.parent = GameObject.Find("Player").transform;
        Destroy(weaponSkill, 5);
    }
}