using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endkampf : MonoBehaviour {

	Player player;
    

	// per Hand verknüpfung in unity, da inaktiv sonst nicht gefunden wird
	public GameObject npcEndkampf;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}
	
	// soll Quest 1 starten ?
	void Update () {
		if (1 == player.getQuest()) {
			npcEndkampf.SetActive (true);
		}
	}
}
