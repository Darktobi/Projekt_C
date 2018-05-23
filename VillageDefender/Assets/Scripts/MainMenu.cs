using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	//Script for the Menu functions of the MainMenu
	
	public void Start(){
		StartCoroutine(VideoTimer());
	}
	void Update () {
		
	}
	public void StartGame(){
	
		
		//Prototyp
	}
	IEnumerator VideoTimer()
    {
        yield return new WaitForSeconds(10);
		SceneManager.LoadScene("Dorf2");
		//sachen wieder aktivieren
		
    }
	public void Quit(){
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit ();
		#endif
	}
	
}
