using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject settingsPanel;
    private BlackOutAnimation BoAnimation;
    
    private void Start()
    {
        BoAnimation = GetComponent<BlackOutAnimation>();
        BoAnimation.EnteringScene();
    }
    public void NewGame()
    {
        GetComponent<AudioSource>().Play();
        BoAnimation.ExitingScene("OpeningScene", 4f);
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

    public void GameOver_continue()
    {
        
        SceneManager.UnloadSceneAsync("GameOver");
    }

    public void GameOver_menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
