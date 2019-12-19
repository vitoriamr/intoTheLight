using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManagerWin : MonoBehaviour {
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
		count =  PlayerPrefs.GetInt("score");
		mText.text = count.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("mainmenu");
		}
	}
}
