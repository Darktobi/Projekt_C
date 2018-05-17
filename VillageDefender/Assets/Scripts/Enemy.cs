using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int attackDmg = 2;
    public int health = 3;
	public GameObject spawnableItem;
	public int maxNumberOfItems = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(health <= 0)
        {
			spawnItem ();
            DestroyObject(gameObject);
        }
	}

    public void takeDamage(int life, Vector2 force, int magnitude)
    {
        //push back player after taking damage
        GetComponent<Rigidbody2D>().AddForce(-force * magnitude);

        health -= life;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();

            // Calculate Angle Between the collision point and the player
            Vector2 force = transform.position - collision.transform.position;
            force.Normalize();

            player.takeDamage(attackDmg, force, 3500);
        }

    }



	// redundant später klasse erstellen?!
	void spawnItem()
	{

		System.Random rnd = new System.Random();

		int numberOfItems = rnd.Next(maxNumberOfItems + 1);
		int xPosition = (int)transform.position.x;
		int yPosition = (int)transform.position.y;


		for (int i = 0; i <= numberOfItems; i++) {
			//MonsterSpawn Wahrscheinlichkeit
			if (rnd.Next (10) < 5) {
				int xValue = rnd.Next (xPosition - 2, xPosition + 2);
				int yValue = rnd.Next (yPosition - 2, yPosition + 2);
				GameObject x = (GameObject)Instantiate (spawnableItem, new Vector3 (xValue, yValue), Quaternion.identity);
			}
		}

	}





}
