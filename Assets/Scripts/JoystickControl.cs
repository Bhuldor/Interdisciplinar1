using System.Collections;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
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
    public bool isAttacking = false;
    public GameObject swordSkill;
    public GameObject axeSkill;
    private GameObject weaponSkill;

    private Animator anim;
    public Animator animAxe;
    public Animator animSword;
    public Animator animDagger;
#if UNITY_EDITOR
    public AnimatorController axeAnimation;
    public AnimatorController daggerAnimation;
    public AnimatorController swordAnimation;
#endif
    public Avatar axeAvatar;
    public Avatar swordAvatar;
    public Avatar daggerAvatar;

    private GameObject weaponCollider;
    public GameObject axeCollider;
    public GameObject swordCollider;
    public GameObject daggerCollider;

    //3d Models
    public GameObject axeModel;
    public GameObject daggerModel;
    public GameObject swordModel;

    //Dash
    public float dashSpeed;
    public float startDashTime;
    public TrailRenderer dashTrail;

    private float dashTime;
    private float attackTime;
    private bool dashed = false;
    private bool skillUsed = false;
    private Vector3 direction;

    public AudioSource walkSound;
    public AudioSource atkSound;

    public static JoystickControl instance;

    private void Start(){
        dashTime = startDashTime;
        dashTrail.enabled = false;
        anim = GetComponent<Animator>();

        Change3dModel(0);
    }

    public void FixedUpdate(){
        direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        rb.velocity = direction;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        rb.constraints &= ~RigidbodyConstraints.FreezePosition;        

        if (direction != new Vector3(0, 0, 0)){
            walkSound.Play();
            anim.SetFloat("Speed", 1);
            anim.SetBool("Attacking", false);
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            
        }
        else
        {
            walkSound.Stop();
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
            atkSound.Play();
            anim.SetBool("Attacking", true);
            isAttacking = true;
            weaponCollider.SetActive(true);
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
        isAttacking = false;
        weaponCollider.SetActive(false);
        anim.SetBool("Attacking", false);
    }

    public void Change3dModel(int weaponType)
    {
        axeModel.SetActive(false);
        swordModel.SetActive(false);
        daggerModel.SetActive(false);

        isSword = false;
        isAxe = false;
        isDagger = false;

        weaponCollider = swordCollider;

        switch (weaponType){
            case 0:
                isSword = true;
                break;
            case 1:
                isAxe = true;
                break;
            case 2:
                isDagger = true;
                break;
            default:
                isSword = true;
                break;
        }

        //Change 3d Model
        if (isAxe){
            axeModel.SetActive(true);
            anim = animAxe;
            weaponCollider = axeCollider;
            //anim.runtimeAnimatorController = axeAnimation as RuntimeAnimatorController;
            //anim.avatar = axeAvatar;
        }
        if (isSword){
            swordModel.SetActive(true);
            anim = animSword;
            weaponCollider = swordCollider;
            //anim.runtimeAnimatorController = swordAnimation as RuntimeAnimatorController;
            //anim.avatar = swordAvatar;
        }
        if (isDagger){
            daggerModel.SetActive(true);
            anim = animDagger;
            weaponCollider = daggerCollider;
            //anim.runtimeAnimatorController = daggerAnimation as RuntimeAnimatorController;
            //anim.avatar = daggerAvatar;
        }
    }
}