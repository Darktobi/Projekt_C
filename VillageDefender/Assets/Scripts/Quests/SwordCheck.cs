using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCheck : MonoBehaviour {


	public GameObject sword;
    public GameObject entry;
    public GameObject jewel;
	private Player player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


		if (player.GetComponent<Player> ().questfortschritt > 0)
		{
			sword.SetActive (false);
            jewel.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
        if(player.GetComponent<Player>().getCollectedSword() > 0)
        {
            entry.SetActive(true);
        }
	}
}
