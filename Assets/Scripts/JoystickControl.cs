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
    private GameObject weaponSkill;
    private bool skillUsed = false;

    private void Start(){
    }

    public void FixedUpdate(){
        Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //BasicAttack
        if (basicAttack.action()) { 
            Debug.Log("Basic");
        }
        //SpecialAttack
        if (specialAttack.action()){
            if (isAxe){
                Debug.Log("Life Steal");
            }else if (isSword){
                //Procura por weaponSkill na cena para permitir a ação
                if (GameObject.FindGameObjectsWithTag("WeaponSkill").Length == 0){
                    skillUsed = true;
                    weaponSkill = Instantiate(swordSkill, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    weaponSkill.transform.parent = GameObject.Find("Player").transform;
                    Destroy(weaponSkill, 5);
                }
                Debug.Log("Shield");
            }else if (isDagger){
                Debug.Log("Dash");
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
}