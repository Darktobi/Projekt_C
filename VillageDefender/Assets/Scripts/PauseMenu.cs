using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public Canvas canvasPause;
	// Use this for initialization
	void Start () {
		GoOnFunktions();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
			canvasPause.gameObject.SetActive(true);
        }
	}
	public void StartGame(){
	
		SceneManager.LoadScene("Dorf2");
	}	
	public void Pause()
    {	
		Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
        Time.timeScale = 0;
    }
	public void GoOnFunktions()
	{
	//	Cursor.lockState = CursorLockMode.Locked;

		//Cursor an aus
      //  Cursor.visible = true;
        canvasPause.gameObject.SetActive(false);
        Time.timeScale = 1;
	}
		public void Quit()
    {
	#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
	#else
        Application.Quit ();
	#endif
    }
	public void To_Main_Menu()
    {
        SceneManager.LoadScene("Hauptmenu");
    }
	
}
