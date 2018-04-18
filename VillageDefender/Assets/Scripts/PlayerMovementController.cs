﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public float speed = 10;

    private enum Direction { Up, Down, Left, Right };

    private Direction currentDirection;
	private static bool playerExists;

    private int attackDirection = 1;


    Rigidbody2D rbody;
    Animator anim;

	public string startPoint;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentDirection = Direction.Up;

		// Szenenwechsel
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

    }

    private void FixedUpdate()
    {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v);

        setCurrentDirection(true, v);
        setCurrentDirection(false, h);

        if (dir != Vector2.zero)
        {

            anim.SetBool("is walking", true);
            anim.SetFloat("input_x", dir.x);
            anim.SetFloat("input_y", dir.y);

        }
        else
        {
            anim.SetBool("is walking", false);
        }

        rbody.velocity = dir.normalized * speed;

        if (Input.GetKeyUp(KeyCode.V))
        {
            Vector3 spawnPos = transform.position + transform.forward;
            if (attackDirection == 1)
            {
                spawnPos += Vector3.up;
            }
            else if (attackDirection == 2)
            {
                spawnPos += Vector3.right;
            }
            else if (attackDirection == 3)
            {
                spawnPos += Vector3.down;
            }
            else if(attackDirection == 4)
            {
                spawnPos += Vector3.left;
            }

            GetComponent<Player>().equippedWeapon.direction = attackDirection;
            Instantiate(GetComponent<Player>().equippedWeapon, spawnPos, transform.rotation);
        }

    }

    private void setCurrentDirection(bool vertical, float value)
    {
        if (vertical)
        {
            if(value == 1)
            {
                attackDirection = 1;
            }
            else if(value == -1)
            {
                attackDirection = 3;
            }

        }

        else
        {
            if(value == 1)
            {
                attackDirection = 2;
            }
            else if (value == -1)
            {
                attackDirection = 4;
            }
        }
    }
}
