using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {
	
	public GameObject endgegner;
	public GameObject bariere;
	public GameObject displayGameOver;
    public AudioSource backgroundMusic;

    void OnTriggerEnter2D(Collider2D other)
	{


		if (other.tag == "Player") {

			if (endgegner != null) {
				endgegner.SetActive (true);

				bariere.SetActive (true);
                backgroundMusic.mute = true;
            }
		} 

		if(endgegner == null) 
		{
			Debug.Log ("GEwonnen");
			displayGameOver.SetActive (true);

		}


	}






}
