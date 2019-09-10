using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject birbSpawn;

	public UnityStandardAssets._2D.Platformer2DUserControl birb;

	public Image StartText;
	public GameObject PauseMenu;
	public GameObject PauseQuit;
	Camera m_MainCamera;
	public int frame;

	// Use this for initialization
	void Start () {
		m_MainCamera = Camera.main;
		birb = FindObjectOfType<UnityStandardAssets._2D.Platformer2DUserControl>();
		Time.timeScale = 0;
		StartText = GameObject.Find("PressStart").GetComponent<Image>();
		PauseMenu = GameObject.Find("MainMenuBtn");
		PauseQuit = GameObject.Find("QuitBtn");
		PauseMenu.SetActive(false);
		PauseQuit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.timeScale == 1 && !birb.GetComponent<Renderer>().isVisible) {
           birb.birbDead = 1;
		}

		if (birb.birbDead == 1)
		{
        	SceneManager.LoadScene("sec");
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			birb.birbDead = 0;
			RespawnBirb();
		}

		if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick 1 button 7"))
		{	
			if (Time.timeScale == 0) {
				StartText.enabled = false;
				PauseMenu.SetActive(false);
				PauseQuit.SetActive(false);
				Time.timeScale = 1;
			}
			else {
				Time.timeScale = 0;
				StartText.enabled = true;
				PauseMenu.SetActive(true);
				PauseQuit.SetActive(true);
			}
		}
	}

	public void RespawnBirb()
	{
		birb.transform.position = birbSpawn.transform.position;
		birb.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
	}
}
