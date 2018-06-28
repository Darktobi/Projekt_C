using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemController : MonoBehaviour {


    public AudioSource audioController;

    public AudioClip collectSound;


    private void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

			if (GetComponent<Item> ().getItemName () == "Holz")
			{

				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().addWood ();
				GameObject item = Resources.Load ("Prefabs/Collectable Objects/Holz") as GameObject;
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().addItem (item.GetComponent<Item> ());
				Destroy (gameObject);
			}

            if (GetComponent<Item>().getItemName() == "Juwel")
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().addJewel();
                Destroy(gameObject);
            }

            if (GetComponent<Item> ().getItemName () == "Schwert") 
			{
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().addSword ();
				Destroy (gameObject);

			}


	        // Lebensenergie zu gewinn
			if (GetComponent<Item> ().getItemName () == "Health") 
			{
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().addLife();
				Destroy (gameObject);

			}

            audioController.PlayOneShot(collectSound);
        }
    }

}
