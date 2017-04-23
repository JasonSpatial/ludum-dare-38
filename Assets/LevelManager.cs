using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private Scene activeScene;

	public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
		activeScene = SceneManager.GetActiveScene();
	}

	public void QuitRequest() {
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(activeScene.buildIndex + 1);
		activeScene = SceneManager.GetActiveScene();
	}
}
