using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadnewArea : MonoBehaviour {

	public string leveltoLoad;
	public string exitPoint;


	private PlayerMovementController thePlayer;




	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerMovementController> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	


	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.name == "Player") {
			Application.LoadLevel (leveltoLoad);

			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			//SceneManager.LoadScene(leveltoLoad, LoadSceneMode.Single);

		




			thePlayer.startPoint = exitPoint;
		}
	}

}
