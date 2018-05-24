using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordQuest : MonoBehaviour {

    private Player player;
    private int jewelCount = 0;

    public GameObject gate;
    private GameObject waechter;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            jewelCount = FindObjectOfType<Player>().getCollectedJewel();

        }

        if (jewelCount >= 1)
        {

            FindObjectOfType<Player>().clearJewel();

            DialogueManager.questprogress = 1;

            gate.SetActive(false);
        }

    }



    // Brücke soll nach szenenwechsel immernoch da sein, wenn SChwert aufgesammelt
    void Start()
    {

        if (FindObjectOfType<Player>().questfortschritt > 0)
        {
            gate.SetActive(false);
        }

    }
}
