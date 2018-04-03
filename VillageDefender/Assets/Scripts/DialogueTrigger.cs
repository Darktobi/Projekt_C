using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	// public bool hasEnterd  = false;

	public Dialogue dialogue;

	/*
	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		// collision.gameObject.GetComponent
	
	}
*/









	void OnTriggerEnter2D(Collider2D other) 
	{ 
		if (other.tag == "Player")
		{ 
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue); 
		}
	}


	void OnTriggerExit2D(Collider2D other2)
	{
		
		//Debug.Log ("Bin raus");

		FindObjectOfType<DialogueManager>().EndDialogue(); 
	}


}
