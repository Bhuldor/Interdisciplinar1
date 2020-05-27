using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
	public static SceneManagerScript Instance { set; get; }

	private void Awake()
	{
		Instance = this;
		
		Load("Vila");
	}

	public void Load(string sceneName)
	{
		if (!SceneManager.GetSceneByName(sceneName).isLoaded){
			SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		}		
	}

	public void Unload(string sceneName)
	{
		if (SceneManager.GetSceneByName(sceneName).isLoaded){
			SceneManager.UnloadSceneAsync(sceneName);
		}
	}
}
