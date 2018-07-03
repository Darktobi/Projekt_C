using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {
	
	public GameObject endgegner;
	public GameObject bariere;
	public GameObject displayGameOver;
    public AudioSource backgroundMusic;
    public AudioClip bossMusic;

    void OnTriggerEnter2D(Collider2D other)
	{
        if (!endgegner.activeInHierarchy)
        {
            if (other.tag == "Player")
            {

                if (endgegner != null)
                {
                    endgegner.SetActive(true);

                    bariere.SetActive(true);
                    backgroundMusic.Stop();

                    backgroundMusic.clip = bossMusic;
                    backgroundMusic.Play();
                }
            }

        }


	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(endgegner == null)
        {
            Debug.Log("Gewonnen");
            displayGameOver.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().endGame(true);


        }
    }






}
