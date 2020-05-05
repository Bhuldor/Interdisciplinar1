using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;
    public string type;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, type);
    }
}
