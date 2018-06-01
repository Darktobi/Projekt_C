using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour {


	public Transform itemsParent;
	InventorySlot[] slots;

	private Player player;

	public Image icon;
	public Text counter;

	//public Animator animator;

	public void addinventar()
	{
	//	animator.SetBool("isOpen", true);
	counter.enabled = true;
	icon.enabled = true;
	counter.text = player.getCollectedWood().ToString();

	}

	public void clearinventar()
	{
		// icon.sprite = null;
		icon.enabled = false;
		counter.enabled = false;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		slots = itemsParent.GetComponentsInChildren<InventorySlot> ();
	}

	// Update is called once per frame
	void Update () {
		if (player.getCollectedWood () > 0) {

			addinventar ();
		} else {
			clearinventar ();
		}

		if (player.getCollectedSword () > 0) {

			//addinventar ();
			slots[1].AddItem ();
			player.addQuest (1);

		}

        if(player.getCollectedJewel() > 0)
        {
            slots[2].AddItem();
        }
        else
        {
            slots[2].SubItem();
        }

	}
}
