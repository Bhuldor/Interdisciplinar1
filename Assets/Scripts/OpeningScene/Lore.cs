using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lore : MonoBehaviour
{
    [SerializeField] protected Button skipTutorial;
    [SerializeField] protected Text skipTutorialText;
    [SerializeField] private AudioSource openingMusic;
    [SerializeField] protected Text messageText;
    [SerializeField] private CanvasGroup blackPanel;
    [TextArea(3, 25)][SerializeField] private string[] lore;
    private Queue<string> sentences;
    protected bool completedText = false;
    private Tutorial tutorial;    
    private bool startedTutorial = false;
    
    void Start()
    {
        tutorial = GetComponent<Tutorial>();
        sentences = new Queue<string>();
        foreach (string lore in lore)
        {
            sentences.Enqueue(lore);
        }
        StartCoroutine(TypeLetters(sentences.Dequeue(), true));
        skipTutorialText.text = "Pular introdução >>";
        skipTutorial.gameObject.SetActive(true);
        skipTutorial.onClick.AddListener(() => SkipLore());
    }

    void Update()
    {
        if (completedText && !startedTutorial)
        {
            StopAllCoroutines();
            if(sentences.Count != 0)
            {
                StartCoroutine(TypeLetters(sentences.Dequeue(), true));
            }
            else
            {
                startedTutorial = true;
                openingMusic.Stop();
                tutorial.StartTutorial();
            }
                
        }
    }

    private void SkipLore()
    {
        skipTutorial.onClick.RemoveListener(() => SkipLore());
        StopAllCoroutines();
        startedTutorial = true;
        openingMusic.Stop();
        LeanTween.alphaCanvas(blackPanel, 0f, 0.5f);
        tutorial.StartTutorial();
    }
    protected IEnumerator TypeLetters(string sentence, bool useUpdate)
    {
        completedText = false;
        messageText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            messageText.text += letter;
            if (letter.Equals('.') || letter.Equals(':'))
            {
                yield return new WaitForSeconds(1f);
            }
            else if (letter.Equals(','))
            {
                yield return new WaitForSeconds(0.5f);
            }


            yield return new WaitForSeconds(0.05f);
        }
        if (useUpdate)
        {
            if (sentences.Count == 0)
            {
                LeanTween.alphaCanvas(blackPanel, 0f, 3f);
            }
            yield return new WaitForSeconds(2f);
        }
        else
            yield return new WaitForSeconds(1f);
        completedText = true;
        
            //StopAllCoroutines();
        
    }
}
