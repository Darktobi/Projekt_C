﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int str = 0;

    public int direction = 1;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, 0.3f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            // Calculate Angle Between the collision point and the player
            Vector2 force = transform.position - collision.transform.position;
            force.Normalize();

            enemy.takeDamage(1, force, 3500);
        }
    }
}
