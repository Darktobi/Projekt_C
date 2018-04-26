using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemController : MonoBehaviour {


	//  1   Item item2;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {


			// 2  item2 = GetComponent<Item> ();

			//  3  Debug.Log (item2.getItemName ());


			    Debug.Log (GetComponent<Item> ().getItemName ());
			if (GetComponent<Item> ().getItemName () == "Holz")
			{

				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().addWood ();
				GameObject item = Resources.Load ("Prefabs/Holz") as GameObject;
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().addItem (item.GetComponent<Item> ());
				Destroy (gameObject);
			}

			if (GetComponent<Item> ().getItemName () == "Schwert") 
			{
				GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().addSword ();



				Destroy (gameObject);

			}

        }
    }

}
