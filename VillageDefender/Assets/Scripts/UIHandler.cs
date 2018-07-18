using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {


	public Image healthstatus;


    public Text playerLife;
 //   public Text collectedWood;
    private Player player;

	public GameObject displayGameOverDead;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        playerLife.text = player.getCurrentLife().ToString();
		healthstatus.fillAmount = (float)player.getCurrentLife () / 100;


		if (player.getCurrentLife () <= 0) {
			Time.timeScale = 0;
			displayGameOverDead.SetActive (true);
            player.endGame(false);
		}
//        collectedWood.text = player.getCollectedWood().ToString();
	}
}
