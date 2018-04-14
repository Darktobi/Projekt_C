using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			thePlayer.startPoint = exitPoint;
		}
	}

}
