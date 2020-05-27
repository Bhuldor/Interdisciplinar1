using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTrigger : MonoBehaviour
{
    public string loadSceneName;
    public string unloadSceneName;
    public GameObject trilhaVila;
    public GameObject loaderToActive;

    private void OnTriggerEnter(Collider other)
    {
        if (loaderToActive != null){
            loaderToActive.SetActive(true);
        }

        if (loadSceneName != ""){
            if (trilhaVila != null){
                trilhaVila.SetActive(false);
            }
            SceneManagerScript.Instance.Load(loadSceneName);
        }

        if (unloadSceneName != ""){
            if (trilhaVila != null){
                trilhaVila.SetActive(true);
            }
            SceneManagerScript.Instance.Unload(unloadSceneName);
            //StartCoroutine(UnloadScene());
        }

        IEnumerator UnloadScene(){
            yield return new WaitForSeconds(.10f);
            SceneManagerScript.Instance.Unload(unloadSceneName);
        }

        this.gameObject.SetActive(false);
    }
}
