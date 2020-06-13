using System.Collections;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackOutAnimation : MonoBehaviour
{
    [SerializeField] private CanvasGroup blackPanel;
    [SerializeField] private GameObject panelToLoad;
    [SerializeField] private bool loadPanel = false;
    
    IEnumerator Begin(float delay)
    {
        yield return new WaitForSeconds(delay);
        LeanTween.alphaCanvas(blackPanel, 0, 1f);
        yield return new WaitForSeconds(1f);
        if(loadPanel)
            panelToLoad.LeanScaleY(1, 0.2f);
        blackPanel.gameObject.SetActive(false);
    }

    IEnumerator FinishAndLoadScene(int sceneToLoad, float delayToLoad)
    {
        blackPanel.gameObject.SetActive(true);
        LeanTween.alphaCanvas(blackPanel, 1, delayToLoad);
        yield return new WaitForSeconds(delayToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator FinishAndLoadScene(string sceneToLoad, float delayToLoad)
    {
        blackPanel.gameObject.SetActive(true);
        LeanTween.alphaCanvas(blackPanel, 1, delayToLoad);
        yield return new WaitForSeconds(delayToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator FinishAndLoadSceneUnload(string sceneToUnload, float delayToLoad)
    {
        blackPanel.gameObject.SetActive(true);
        LeanTween.alphaCanvas(blackPanel, 1, delayToLoad);
        yield return new WaitForSeconds(delayToLoad);
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }
    IEnumerator FinishAndLoadSceneAsync(string sceneToLoad, float delayToLoad)
    {
        blackPanel.gameObject.SetActive(true);
        LeanTween.alphaCanvas(blackPanel, 1, delayToLoad);
        yield return new WaitForSeconds(delayToLoad);
        SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
    }

    public void EnteringScene(float delayToStart)
    {
        StartCoroutine(Begin(delayToStart));
    } 

    public void ExitingScene(int sceneToLoad, float delayToLoad)
    {
        StartCoroutine(FinishAndLoadScene(sceneToLoad, delayToLoad));
    }
    public void ExitingScene(string sceneToLoad, float delayToLoad)
    {
        StartCoroutine(FinishAndLoadScene(sceneToLoad, delayToLoad));
    }
    public void ExitingSceneAsync(string sceneToLoad, float delayToLoad)
    {
        StartCoroutine(FinishAndLoadSceneAsync(sceneToLoad, delayToLoad));
    }

    public void ExitingSceneUnload(string sceneToUnload, float delayToUnload)
    {
        StartCoroutine(FinishAndLoadSceneUnload(sceneToUnload,delayToUnload));
    }
}
