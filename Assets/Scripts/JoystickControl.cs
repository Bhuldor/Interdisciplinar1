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
            Debug.Log("SpecialAttack");
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