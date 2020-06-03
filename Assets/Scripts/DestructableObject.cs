using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    private JoystickControl control;

    private void Start()
    {
        control = FindObjectOfType<JoystickControl>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (control.isAttacking)
                Destroy(this.gameObject);
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (control.isAttacking)
                Destroy(this.gameObject);
        }
    }
}
