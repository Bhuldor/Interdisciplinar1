
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("WorldScene");
    }

    public void BackMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
