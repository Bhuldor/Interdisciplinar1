using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector3 position;
            if(Input.touchCount > 0)
            {
                position = Input.GetTouch(0).position;
            }
            else
            {
                position = Input.mousePosition;
            }
            Ray ray = cam.ScreenPointToRay(position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                var interactable = hit.collider.GetComponent < Interactable >();
                if(interactable != null)
                {
                    switch (interactable.interactionType)
                    {
                        case Interactable.InteractionType.NPC:
                            if(interactable.checkDistance(transform)){
                                if (interactable.eventToPlay != null)
                                    interactable.eventToPlay.Invoke();
                            }
                            break;
                    }
                }
            }
        }
    }
}
