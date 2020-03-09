using UnityEngine;

public class PlayerController : MonoBehaviour{

    [Header("Settings")]
    public float moveSpeed = 5f;
    public GunController gunController;

    //Private Settings
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Rigidbody mRigidbody;

    private Camera mainCamera;

    void Start(){
        mRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }
   
    void Update(){
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLenght;

        if (groundPlane.Raycast(cameraRay, out rayLenght)){
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0)){
            //Debug.Log("True");
            gunController.isFiring = true;
        }

        if (Input.GetMouseButtonUp(0)){
            //Debug.Log("False");
            gunController.isFiring = false;
        }
    }

    private void FixedUpdate(){
        mRigidbody.velocity = moveVelocity;
    }
}
