using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private string type;

    public Text nameText;
    public Text messageText;
    public GameObject messagePanel;

    public float delayToOpenMessageBox = 1f;
    public float delayToWriteMessage = 1f;

    public delegate void ChatFinished();
    public static event ChatFinished onChatFinished;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, string type)
    {
        this.type = type;
        LeanTween.scale(messagePanel, new Vector3(1, 1, 1), delayToOpenMessageBox*0.2f);
        nameText.text = dialogue.name;

        sentences.Clear();
        

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            if (type == "store")
                onChatFinished?.Invoke();

            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLetters(sentence));
    }

    IEnumerator TypeLetters(string sentence)
    {
        messageText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            messageText.text += letter;
            yield return new WaitForSeconds(delayToWriteMessage/100);
        }
    }

    void EndDialogue()
    {
        LeanTween.scale(messagePanel, new Vector3(0, 0, 0), delayToOpenMessageBox*0.2f);
    }
}
