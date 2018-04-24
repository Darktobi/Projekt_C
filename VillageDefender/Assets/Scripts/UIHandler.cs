using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

    public Text playerLife;
 //   public Text collectedWood;
    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        playerLife.text = player.getCurrentLife().ToString();
//        collectedWood.text = player.getCollectedWood().ToString();
	}
}
