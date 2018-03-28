using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int attackDmg = 2;
    public int health = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(health <= 0)
        {
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
}
