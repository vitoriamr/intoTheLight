using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject birbSpawn;
	public UnityStandardAssets._2D.Platformer2DUserControl player;

	public GameObject birb;
	public GameObject foxr;
	public GameObject posun;

	public Text countText;

	public Image StartText;
	public GameObject PauseMenu;
	public GameObject PauseQuit;
	Camera m_MainCamera;
	public int frame;
	private int count;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<UnityStandardAssets._2D.Platformer2DUserControl>();

		m_MainCamera = Camera.main;
		birb = GameObject.Find("Birb");
		foxr = GameObject.Find("Foxr");
		foxr.SetActive(false);
		posun = GameObject.Find("Posun");
		posun.SetActive(false);
		Time.timeScale = 0;
		StartText = GameObject.Find("PressStart").GetComponent<Image>();
		PauseMenu = GameObject.Find("MainMenuBtn");
		PauseQuit = GameObject.Find("QuitBtn");
		PauseMenu.SetActive(false);
		PauseQuit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.timeScale == 1 && !player.GetComponent<Renderer>().isVisible) {
           player.birbDead = 1;
		}

		if (player.birbDead == 1)
		{
        	SceneManager.LoadScene("sec");
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			player.birbDead = 0;
			RespawnBirb();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			if(birb.activeSelf == true) {
				birb.SetActive(false);
				foxr.SetActive(true);
			} else if (foxr.activeSelf == true) {
				foxr.SetActive(false);
				posun.SetActive(true);
			} else if (posun.activeSelf == true) {
				posun.SetActive(false);
				birb.SetActive(true);
			}
			
			player = FindObjectOfType<UnityStandardAssets._2D.Platformer2DUserControl>();

		}

		if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick 1 button 7"))
		{	
			player = FindObjectOfType<UnityStandardAssets._2D.Platformer2DUserControl>();
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

	void FixedUpdate () {
		count = Mathf.RoundToInt(Time.timeSinceLevelLoad);
		countText.text = "Score:  " + count.ToString();
	}

	public void RespawnBirb()
	{
		count = 0;
		player.transform.position = birbSpawn.transform.position;
		player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
	}
}
