using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public float speed = 10;

    private enum Direction { Up, Down, Left, Right };

    private Direction currentDirection;
	private static bool playerExists;

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
            if (currentDirection == Direction.Right)
            {
                spawnPos += Vector3.right;
            }
            else if(currentDirection == Direction.Left)
            {
                spawnPos += Vector3.left;
            }
            else if(currentDirection == Direction.Up)
            {
                spawnPos += Vector3.up;
            }
            else if(currentDirection == Direction.Down)
            {
                spawnPos += Vector3.down;  
            }
            
           GameObject g = (GameObject)Instantiate(GetComponent<Player>().equippedWeapon, spawnPos, transform.rotation);
        }

    }

    private void setCurrentDirection(bool vertical, float value)
    {
        if (vertical)
        {
            if(value == 1)
            {
                currentDirection = Direction.Up;
            }
            else if(value == -1)
            {
                currentDirection = Direction.Down;
            }

        }

        else
        {
            if(value == 1)
            {
                currentDirection = Direction.Right;
            }
            else if (value == -1)
            {
                currentDirection = Direction.Left;
            }
        }
    }
}
