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
    [SerializeField] private GameObject menuButton;

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
        SceneManager.LoadScene(1);
    }

    private void HealthBar()
    {
        LeanTween.alphaCanvas(healthBar.GetComponent<CanvasGroup>(), 1f, 2f);
        StartCoroutine(
            waitAndExecuteLambda(2f, () => {

                messageTextPanel.SetActive(true);
                var rt = healthBar.GetComponent<RectTransform>();
                messageTextRT.sizeDelta = new Vector2(rt.sizeDelta.x * 4, rt.sizeDelta.y * 8);
                StartCoroutine(TypeLetters("Se atente a sua barra de vida \n Se ela chegar a 0, \nsua aventura chegara ao fim!", false));
                messageText.transform.position = healthBar.transform.position - new Vector3(-healthBar.transform.position.x, healthBar.transform.position.y / 10, 0);

                messageTextPanelRT.sizeDelta = messageTextRT.sizeDelta;
                messageTextPanel.transform.position = messageText.transform.position;

                },
                () => LeftController()
            )
        );
    }

    private void LeftController()
    {
        LeanTween.alphaCanvas(leftControl.GetComponent<CanvasGroup>(), 1f, 2f);
        StartCoroutine(
            waitAndExecuteLambda(2f, () =>
            {
                messageTextPanel.SetActive(true);
                var rt = leftControl.GetComponent<RectTransform>();
                messageTextRT.sizeDelta = new Vector2(rt.sizeDelta.x * 6, rt.sizeDelta.y);
                StartCoroutine(TypeLetters("Utilize esse controle para movimentar Kaluana.", false));
                messageText.transform.position = leftControl.transform.position + new Vector3(+leftControl.transform.position.x * 2, +leftControl.transform.position.y * 1f, 0);

                messageTextPanelRT.sizeDelta = messageTextRT.sizeDelta;
                messageTextPanel.transform.position = messageText.transform.position;

            },
            () => RightController()
            )
        );
    }
    private void RightController()
    {
        LeanTween.alphaCanvas(rightControl.GetComponent<CanvasGroup>(), 1f, 2f);
        StartCoroutine(
            waitAndExecuteLambda(2f, () =>
            {
                messageTextPanel.SetActive(true);
                var rt = rightControl.GetComponent<RectTransform>();
                messageTextRT.sizeDelta = new Vector2(rt.sizeDelta.x * 10, rt.sizeDelta.y * 14);
                StartCoroutine(TypeLetters("Utilize o botão principal com icone de sua arma para atacar.", false));
                messageText.transform.position = rightControl.transform.position - new Vector3(-rightControl.transform.position.x / 8, rightControl.transform.position.y / 4, 0);

                messageTextPanelRT.sizeDelta = messageTextRT.sizeDelta;
                messageTextPanel.transform.position = messageText.transform.position;
            },
            () => StartCoroutine(
                    waitAndExecuteLambda(0f, () =>
                    {
                        messageTextPanel.SetActive(true);
                        StartCoroutine(TypeLetters("O botão menor é sua habilidade única da arma:\nAdaga realiza uma esquiva.\nEspada cria um escudo.\nMachado lhe da roubo de vida.", false));

                        messageTextPanelRT.sizeDelta = messageTextRT.sizeDelta;
                        messageTextPanel.transform.position = messageText.transform.position;
                    },
                    () => StartCoroutine(
                            waitAndExecuteLambda(0f, () =>
                            {
                                messageTextPanel.SetActive(true);
                                StartCoroutine(TypeLetters("Os dois botões em cinza serão liberados com o decorrer do jogo.", false));

                                messageTextPanelRT.sizeDelta = messageTextRT.sizeDelta;
                                messageTextPanel.transform.position = messageText.transform.position;
                            },
                            () => Menu()
                            ) // 3º Lambda ending
                         ) // 3º CoroutineEnding   
                    ) // 2º Lambda ending
                ) // 2º CoroutineEnding
            )// 1º Lambda Ending
        ); // 1º CoroutineEnding
    }

    private void Menu()
    {
        LeanTween.alphaCanvas(menuButton.GetComponent<CanvasGroup>(), 1f, 2f);
        StartCoroutine(
            waitAndExecuteLambda(2f, () =>
            {
                messageTextPanel.SetActive(true);
                var rt = menuButton.GetComponent<RectTransform>();
                messageTextRT.sizeDelta = new Vector2(rt.sizeDelta.x * 10, rt.sizeDelta.y * 6);
                StartCoroutine(TypeLetters("Toque no pergaminho para pausar e abrir o menu.", false));
                messageText.transform.position = menuButton.transform.position - new Vector3(0, +menuButton.transform.position.y / 8, 0);

                messageTextPanelRT.sizeDelta = messageTextRT.sizeDelta;
                messageTextPanel.transform.position = messageText.transform.position;

            },
            () => LoadLevelScene()
            )
        );
    }

    IEnumerator waitAndExecuteLambda(float timeToWait, Action lambda, Action nextFunction)
    {
        yield return new WaitForSeconds(timeToWait);
        lambda();
        while (!completedText)
        {
            yield return null;
        }
        messageTextPanel.SetActive(false);
        messageText.text = "";
        yield return new WaitForSeconds(1f);
        nextFunction();
    }
}
