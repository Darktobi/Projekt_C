using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int questfortschritt = 0;
    public int life = 100;
    private int collectedWood = 0;
	private int collectedSword = 0;
    private int collectedJewel = 0;

    private Inventory inventory;

    public Weapon equippedWeapon;

	public AudioSource audioController;

	public AudioClip takeDamageSound;

	// Use this for initialization
	void Start () {
        inventory = GetComponent<Inventory>();
				}



	// Bei Szenenwechsel muss die Verknüpfung zum Audiocontroller wiederhergestellt werden.
	void Update(){
		
		audioController = GameObject.Find ("AudioController").GetComponent<AudioSource>();

	}



	// Update is called once per frame
	/*
	void Update () {
		
        if(life <= 0)
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit ();
            #endif
        }
    }
	*/

    public void takeDamage(int life, Vector2 force, int magnitude)
    {
        //push back player after taking damage
        GetComponent<Rigidbody2D>().AddForce(-force * magnitude);

        this.life -= life;
		audioController.PlayOneShot (takeDamageSound);
    }

    public int getCurrentLife()
    {
        return life;
    }

	public void addLife()
	{
		if (this.life < 100) {
			life = life + 10;
		}
	}

    public void addItem(Item item)
    {
        inventory.addItem(item);
        inventory.showItem();
    }

    public void addWood()
    {
        collectedWood++;
       
    }

    public void addJewel()
    {
        collectedJewel++;
    }

	public void clearWood()
	{
		collectedWood = 0;
	}

    public void clearJewel()
    {
        collectedJewel = 0;
    }

    public void addSword()
	{
		collectedSword++;

	}

    public int getCollectedWood()
    {
        return collectedWood;
    }

    public int getCollectedJewel()
    {
        return collectedWood;
    }

    public int getCollectedSword()
	{
		return collectedSword;
	}

	public void addQuest (int questzahl)
	{
		questfortschritt = questzahl;

	}

	public int getQuest()
	{
		return questfortschritt;
	}


}
