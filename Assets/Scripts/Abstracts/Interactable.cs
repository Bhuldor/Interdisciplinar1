using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public float radius = 4f;

    public UnityEvent eventToPlay;

    public enum InteractionType {
        NPC
    };

    public InteractionType interactionType = InteractionType.NPC;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public bool checkDistance(Transform player)
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < radius)
            return true;
        else
            return false;
    }
}
