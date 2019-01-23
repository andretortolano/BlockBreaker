using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadStartScene() {
		FindObjectOfType<GameStatus>().ClearScore();
		SceneManager.LoadScene(0);
	}

	public void quit() {
		Application.Quit();
	}
}
