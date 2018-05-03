using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseMovementController : MonoBehaviour {

    public float speed = 1;
    public float chaseRange = 5;

    private bool isChasing;

    Vector2 dir;

    GameObject target;
    EnemyAnimation enemyAnimation;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
        enemyAnimation = GetComponent<EnemyAnimation>();
        dir = new Vector2();
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

        enemyAnimation.animate(dir, isChasing);
	}

    private void move()
    {
        dir = (target.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = dir * speed;
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
}
