using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int life = 100;
    private int collectedWood = 0;
	private int collectedSword = 0;

    private Inventory inventory;

    public Weapon equippedWeapon;

	// Use this for initialization
	void Start () {
        inventory = GetComponent<Inventory>();
	}
	
	// Update is called once per frame
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

    public void takeDamage(int life, Vector2 force, int magnitude)
    {
        //push back player after taking damage
        GetComponent<Rigidbody2D>().AddForce(-force * magnitude);

        this.life -= life;
    }

    public int getCurrentLife()
    {
        return life;
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

	public void addSword()
	{
		collectedSword++;

	}

    public int getCollectedWood()
    {
        return collectedWood;
    }

	public int getCollectedSword()
	{
		return collectedSword;
	}
}
