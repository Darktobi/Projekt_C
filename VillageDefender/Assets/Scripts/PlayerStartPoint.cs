using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {


	static private PlayerMovementController thePlayer;
	private camerafollow theCam;

	public string pointName;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<PlayerMovementController> ();


		if (thePlayer.startPoint == pointName) {
			thePlayer.transform.position = transform.position;

			theCam = FindObjectOfType<camerafollow> ();
			theCam.transform.position = new Vector3 (transform.position.x, transform.position.y, theCam.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
