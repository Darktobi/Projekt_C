using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColision : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other) 
	{ 
		if (other.tag == "Player")
		{ 
			DialogueManager.questprogress = 1;
		}
	}

}
