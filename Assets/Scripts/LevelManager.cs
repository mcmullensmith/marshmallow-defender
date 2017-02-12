using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void Quit() {
		print("Quit application");
		Application.Quit();
	}

	public void LoadScene(string name) {
		print("Load scene by name");
		SceneManager.LoadScene(name);
	}

	public void LoadNextScene() {
		print("Load next scene");
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex + 1);
	}

	public void LoadPrevScene() {
		print("Load previous scene");
		int currentIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentIndex - 1);
	}

	public void ReloadScene() {
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
