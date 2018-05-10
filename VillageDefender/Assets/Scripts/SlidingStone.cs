﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingStone : MonoBehaviour {

    private bool hasSlide;

    private float startX;
    private float startY;

    private float currentX;
    private float currentY;

    public float movePx = 1;
    public float slideTimer = 0.4f;
    public float positionTimer = 0.5f;

	// Use this for initialization
	void Start () {
        hasSlide = false;
        startX = transform.position.x;
        startY = transform.position.y;
        currentX = startX;
        currentY = startY;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(hasSlide)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            if(positionTimer <= 0)
            {
                currentX = transform.position.x;
                currentY = transform.position.y;
                
            }
            else
            {
                positionTimer -= Time.deltaTime;
            }
        }
	}

    public void reset()
    {
        transform.position = new Vector2(startX, startY);
        hasSlide = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SlideStone" || collision.gameObject.tag == "Wall")
        {
            transform.position = new Vector2(currentX, currentY);

            if (hasSlide)
            {
                //Only stone that has moved can slide again
                if(currentX == startX && currentY == startY)
                {
                    hasSlide = false;
                    positionTimer = 0.5f;
                }
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!hasSlide)
            {
                if (slideTimer <= 0)
                {
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    move(collision);
                    GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                    hasSlide = true;
                }
                slideTimer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            slideTimer = 0.4f;

        }
    }

    private void move(Collider2D collision)
    {
        // In which Direction should the block move

        //Right
        if (collision.transform.position.x <= transform.position.x - 0.6f)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x + movePx, transform.position.y);
        }
        //Left
        else if(collision.transform.position.x >= transform.position.x + 0.6f)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x - movePx, transform.position.y);
        }
        //Down
        else if (collision.transform.position.y >= transform.position.y + 0.7f)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x, transform.position.y - movePx);
        }
        //Up
        else if (collision.transform.position.y <= transform.position.y - 0.7f)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x, transform.position.y + movePx);
        }
    }

}
