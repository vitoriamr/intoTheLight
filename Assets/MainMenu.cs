using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void ToMenu() {
		SceneManager.LoadScene("MainMenu");
	}
	public void ToMaps() {
		SceneManager.LoadScene("MapSelector");
	}
	public void ToOriginal() {
		SceneManager.LoadScene("sec");
	}
	public void ToDesktop() {
		Application.Quit();
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick 2 button 6") || Input.GetKeyDown("joystick 2 button 6"))
		{
			SceneManager.LoadScene("sec");
		}
	}
}
