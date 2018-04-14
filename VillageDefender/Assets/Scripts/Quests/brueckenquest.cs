using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brueckenquest : MonoBehaviour {
	private Player player;
	private int holzanzahl = 0;

	private GameObject bruecke;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {

			holzanzahl =  FindObjectOfType<Player> ().getCollectedWood ();
				
			}

	



		if (holzanzahl >= 5) {

			// Holzbrücke anzeigen
			bruecke = GameObject.Find ("Holzbruecke");
			bruecke.GetComponent<Renderer>().enabled = true;

					
			Destroy (gameObject);



		}

	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
