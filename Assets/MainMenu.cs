using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void ToMenu() {
		Application.LoadLevel("MainMenu");
	}
	public void ToMaps() {
		Application.LoadLevel("MapSelector");
	}
	public void ToOriginal() {
		Application.LoadLevel("sec");
	}
	public void ToDesktop() {
		Application.Quit();
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			Application.LoadLevel("sec");
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Application.Quit();
		}
	}
}
