using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkWaypointChaseSwitch : MonoBehaviour {





	// Use this for initialization
	void Start () {

		GetComponent<EnemyChaseMovementController> ().enabled = false;


	}



	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Player")
		{
			GetComponent<NPCAnimationWaypoint> ().enabled = false;
			GetComponent<EnemyChaseMovementController> ().enabled = true;

		}
	} 

	
	// Update is called once per frame
	void Update () {

	

		
	}
}
