using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	//Script for the Menu functions of the MainMenu
	
	public void Start(){
	
	}
	void Update () {
		
	}
	public void StartGame(){
		SceneManager.LoadScene("Dorf2");
		//Prototyp
	}
	
	public void Quit(){
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit ();
		#endif
	}
	
}
