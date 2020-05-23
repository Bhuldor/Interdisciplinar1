using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : Lore
{
    //[SerializeField] private Text messageText;
    [SerializeField] private GameObject messageTextPanel;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject leftControl;
    [SerializeField] private GameObject rightControl;
    [SerializeField] private GameObject MenuButton;

    private RectTransform messageTextRT;
    private RectTransform messageTextPanelRT;
    
    void Start()
    {
        messageTextRT = messageText.gameObject.GetComponent<RectTransform>();
        messageTextPanelRT = messageTextPanel.GetComponent<RectTransform>();
    }

    void Update()
    {
        
    }

    public void StartTutorial()
    {
        messageText.resizeTextForBestFit = true;
        messageText.alignment = TextAnchor.MiddleCenter;
        

        HealthBar();
    }

    private void LoadLevelScene()
    {
        SceneManager.LoadScene(2);
    }

    private void HealthBar()
    {
        healthBar.SetActive(true);
        LeanTween.alphaCanvas(healthBar.GetComponent<CanvasGroup>(), 1f, 2f);
        StartCoroutine(waitAndExecuteLambda(2f, () => {

            messageTextPanel.SetActive(true);
            messageTextRT.sizeDelta = new Vector2(healthBar.GetComponent<RectTransform>().sizeDelta.x * 4, healthBar.GetComponent<RectTransform>().sizeDelta.y * 5);
            StartCoroutine(TypeLetters("Se atente a sua barra de vida \n Se ela chegar a 0, sua aventura chegara ao fim!", false));
            messageText.transform.position = healthBar.transform.position - new Vector3(-healthBar.transform.position.x, healthBar.transform.position.y / 10, 0);

            messageTextPanelRT.sizeDelta = messageTextRT.sizeDelta;
            messageTextPanel.transform.position = messageText.transform.position;

        }
        ));

    }

    IEnumerator waitAndExecuteLambda(float timeToWait, Action lambda)
    {
        yield return new WaitForSeconds(timeToWait);
        lambda();
    }
}
