using UnityEngine;

public class GunController : MonoBehaviour{

    [Header("Settings")]
    public bool isFiring = false;
    public BulletController bullet;
    public float bulletSpeed = 7.5f;
    public float fireRate;
    public Transform firePoint;

    //Privates
    private float shotCounter;

    void Start(){
        
    }
   
    void Update(){
        if (isFiring){
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0){
                shotCounter = fireRate;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.moveSpeed = bulletSpeed;
            }
        }
        else{
            shotCounter = 0;
        }
    }
}
