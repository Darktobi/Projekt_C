using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCheck : MonoBehaviour {


	public GameObject sword;
	private Player player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


		if (player.GetComponent<Player> ().questfortschritt > 0)
		{
			sword.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
