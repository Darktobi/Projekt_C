using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public float speed = 1;

    GameObject target;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 v2 = (target.transform.position - transform.position).normalized;
        //Debug.Log(v2);

        changeAnimation(v2);
        GetComponent<Rigidbody2D>().velocity = v2 * speed;
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
