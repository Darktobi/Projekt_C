﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCollectable : MonoBehaviour {

    public GameObject spawnableItem;
   //  public float interval = 2;

    public int life = 3;
	private int lifestatus;
    public int maxNumberOfItems = 5;

	public GameObject spawnMonster;
	public AudioSource audioController;
	public AudioClip chopwood;
	public AudioClip treefalldown;
	public Image healthstatus;
	public GameObject healthbar;


	//Healthbar variable für Anzeigenberechung
	private void Start(){
		lifestatus = life;
	}



    private void FixedUpdate()
    {
        if (lifestatus <= 0)
        {
            spawnItem();
			audioController.PlayOneShot (treefalldown);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            if (Input.GetKeyUp(KeyCode.Space))
            {


			//verhindert schnelles baumfällen, wartet auf ende sound
				if (!audioController.isPlaying) {

					audioController.PlayOneShot (chopwood);
				
					lifestatus--;

					//Healthbar wird aktuallisiert
					healthbar.SetActive(true);
					healthstatus.fillAmount = (float)lifestatus / (float)life;
				}
            }
        }
    }

    void spawnItem()
    {
        
        System.Random rnd = new System.Random();

        int numberOfItems = rnd.Next(maxNumberOfItems + 1);
		int xPosition = (int)transform.position.x;
        int yPosition = (int)transform.position.y;

        for(int i = 0; i<=numberOfItems; i++)
        {
            int xValue = rnd.Next(xPosition -2, xPosition +2);
            int yValue = rnd.Next(yPosition -2, yPosition +2);
            GameObject g = (GameObject)Instantiate(spawnableItem, new Vector3(xValue, yValue), Quaternion.identity);
        }

		//MonsterSpawn Wahrscheinlichkeit
		if (rnd.Next (10) < 5) {
			int xValue = rnd.Next(xPosition -2, xPosition +2);
			int yValue = rnd.Next(yPosition -2, yPosition +2);
			GameObject x = (GameObject)Instantiate(spawnMonster, new Vector3(xValue, yValue), Quaternion.identity);
		}


    }
}
