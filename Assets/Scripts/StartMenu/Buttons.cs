using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject settingsPanel;

    public void NewGame()
    {
        SceneManager.LoadScene("WorldScene");
    }
    public void Continue()
    {

    }
    public void OpenOptions()
    {
        LeanTween.scale(settingsPanel, new Vector3(1f,1f,1f), 0.1f);
    }

    public void CloseOptions()
    {
        LeanTween.scale(settingsPanel, new Vector3(0.0001f, 0.0001f, 0.0001f), 0.1f);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
