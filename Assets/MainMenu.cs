using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	Scene currentScene;

	public void ToMenu() {
		SceneManager.LoadScene("MainMenu");
	}
	public void ToMaps() {
		SceneManager.LoadScene("MapSelector");
	}
	public void ToOriginal() {
		SceneManager.LoadScene("map");
	}
	public void ToDesktop() {
		Application.Quit();
	}
	void Update () {
		currentScene = SceneManager.GetActiveScene ();
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("MainMenu");
		}
		if (Input.GetKeyDown(KeyCode.S) && currentScene.name == "mainmenu")
		{
			SceneManager.LoadScene("map");
		}
		if (Input.GetKeyDown(KeyCode.Q) && currentScene.name == "mainmenu")
		{
			Application.Quit();
		}
	}
}
