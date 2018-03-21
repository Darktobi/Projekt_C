using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int attackDmg = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
