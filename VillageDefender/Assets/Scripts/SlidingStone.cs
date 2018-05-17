using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingStone : MonoBehaviour {

    private bool hasSlide;
    private bool hasForecast;
    private bool canMove;

    private int moveDirection;

    private float slideTimer;
    private float positionTimer;

    private float startX;
    private float startY;

    private PlayerMovementController playerMovement;

    public float movePx = 1;
    public float startSlideTimer = 0.2f;
    public float startPositionTimer = 0.2f;

    public GameObject forecast;

    // Use this for initialization
    void Start () {
        hasSlide = false;
        startX = transform.position.x;
        startY = transform.position.y;
        slideTimer = startSlideTimer;
        positionTimer = startPositionTimer;

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementController>();
    }
	
	// Update is called once per frame
	void Update () {
		
        //If Forecast finds free position, slide Stone in that direction
        if(hasForecast && !hasSlide)
        {
            if(positionTimer <= 0)
            {
                canMove = true;
            }
            else
            {
                positionTimer -= Time.deltaTime;
            }
        }

        // Move slide stone if forecast stay on free position for a few moments
        if (canMove)
        {
            forecast.transform.position = new Vector2(startX, startY);
            move();
            canMove = false;
            hasSlide = true;
            positionTimer = startPositionTimer;
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
	}

    public void reset()
    {
        transform.position = new Vector2(startX, startY);
        forecast.transform.position = new Vector2(startX, startY);
        hasForecast = false;
        hasSlide = false;
        positionTimer = startPositionTimer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SlideStone" || collision.gameObject.tag == "Wall")
        {
            // remove only forecast from SlideStone that haven't moved
            if (hasForecast && !hasSlide)
            {
                forecast.transform.position = new Vector2(startX, startY);
                hasForecast = false;
                positionTimer = startPositionTimer;
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //Forecast stone moving only if player presses long enough against the stone
        if (collision.gameObject.tag == "Player")
        {
            if (!hasForecast && playerMovement.isMoving)
            {
                if (slideTimer <= 0)
                {
                    moveForecast(collision);
                    hasForecast = true;
                }
                slideTimer -= Time.deltaTime;
            }
            else
            {
                slideTimer = startSlideTimer;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            slideTimer = startSlideTimer;
        }
    }

    private void move()
    {
        // In which Direction should the block move

        //Right
        if (moveDirection == 0)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x + movePx, transform.position.y);
        }
        //Left
        else if(moveDirection == 1)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x - movePx, transform.position.y);
        }
        //Down
        else if (moveDirection == 2)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x, transform.position.y - movePx);
        }
        //Up
        else if (moveDirection == 3)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector2(transform.position.x, transform.position.y + movePx);
        }
    }

    private void moveForecast(Collider2D collision)
    {
        // In which Direction should the forecast move

        //Right
        if (collision.transform.position.x <= transform.position.x - 0.6f)
        {
            forecast.transform.position = new Vector2(transform.position.x + movePx, transform.position.y);
            moveDirection = 0;
        }
        //Left
        else if (collision.transform.position.x >= transform.position.x + 0.6f)
        {
           forecast.transform.position = new Vector2(transform.position.x - movePx, transform.position.y);
            moveDirection = 1;
        }
        //Down
        else if (collision.transform.position.y >= transform.position.y + 0.7f)
        {
            forecast.transform.position = new Vector2(transform.position.x, transform.position.y - movePx);
            moveDirection = 2;
        }
        //Up
        else if (collision.transform.position.y <= transform.position.y - 0.7f)
        {
            forecast.transform.position = new Vector2(transform.position.x, transform.position.y + movePx);
            moveDirection = 3;
        }
    }

}
