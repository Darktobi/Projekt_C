using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCheck : MonoBehaviour {


	public GameObject sword;
    public GameObject entry;
    public GameObject jewel;
    private int jewelCount = 0;
    private Player player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        jewelCount = FindObjectOfType<Player>().getCollectedJewel();


        if (player.GetComponent<Player> ().questfortschritt > 0)
		{
			sword.SetActive (false);
            jewel.SetActive(false);
		}

        else if(jewelCount > 0)
        {
            jewel.SetActive(false);
        }
	}
	
}
