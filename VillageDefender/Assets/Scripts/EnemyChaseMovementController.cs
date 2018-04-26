using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseMovementController : MonoBehaviour {

    public float speed = 1;
    public float chaseRange = 5;

    private bool isChasing;

    GameObject target;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        if(isChasing)
        {
            move();
            isChasing = targetInRange();
            
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

	}

    private void move()
    {
        Vector2 v2 = (target.transform.position - transform.position).normalized;
        changeAnimation(v2);
        GetComponent<Rigidbody2D>().velocity = v2 * speed;
    }

    private bool targetInRange()
    {
        if (transform.position.x - chaseRange > target.transform.position.x || transform.position.x + chaseRange < target.transform.position.x)
        {
            return false;
        }
        else if (transform.position.y - chaseRange > target.transform.position.y || transform.position.y + chaseRange < target.transform.position.y)
        {
            return false;
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            isChasing = true;
        }
    }

    void changeAnimation(Vector2 v)
    {
        if(v.y > 0)
        {
            if(v.y < 0.3f)
            {
                if(v.x > 0)
                {
                    anim.SetInteger("direction", 2);
                }
                else if (v.x < 0)
                {
                    anim.SetInteger("direction", 4);
                }
            }
            else
            {
                anim.SetInteger("direction", 1);
            }  
        }
        else if(v.y < 0)
        {
            if (v.y > -0.3f)
            {
                if (v.x > 0)
                {
                    anim.SetInteger("direction", 2);
                }
                else if (v.x < 0)
                {
                    anim.SetInteger("direction", 4);
                }
            }
            else
            {
                anim.SetInteger("direction", 3);
            }
        }
    }


}
