using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManagerMap : MonoBehaviour {
	public TextMeshPro mText;
	Camera m_MainCamera;
	public int frame;
	private int count;
	public AudioClip clip1;
	public AudioClip clip2;
	AudioSource m_MyAudioSource;
	Scene currentScene;

	// Use this for initialization
	void Start () {
		m_MyAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		currentScene = SceneManager.GetActiveScene ();
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("mainmenu");
		}
		if (Input.GetKeyDown(KeyCode.E) && currentScene.name == "map")
		{
			SceneManager.LoadScene("first");
		}
		if (Input.GetKeyDown(KeyCode.M) && currentScene.name == "map")
		{
			SceneManager.LoadScene("third");
		}
		if (Input.GetKeyDown(KeyCode.H) && currentScene.name == "map")
		{
			SceneManager.LoadScene("sec");
		}
	}
}
