﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brueckenquest : MonoBehaviour {
	private Player player;
	private int holzanzahl = 0;

	public GameObject bruecke;
	private GameObject waechter;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {

			holzanzahl =  FindObjectOfType<Player> ().getCollectedWood ();
				
			}

	



		if (holzanzahl >= 5) {

			FindObjectOfType<Player> ().clearWood ();

			DialogueManager.questprogress = 1;	

			bruecke.SetActive (true);




		// Holzbrücke anzeigen
		//	bruecke = GameObject.Find ("Holzbruecke");
		//	bruecke.GetComponent<Renderer>().enabled = true;



			waechter = GameObject.Find ("Brueckenwaechter");
			Destroy (waechter);

				
			//Destroy (gameObject);



		}

	}



	// Brücke soll nach szenenwechsel immernoch da sein, wenn SChwert aufgesammelt
	void Start () {

		if (FindObjectOfType<Player> ().questfortschritt > 0) {
			bruecke.SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
