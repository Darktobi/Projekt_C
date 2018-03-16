using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public float speed = 10;

    Rigidbody2D rbody;
    Animator anim;

    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    private void FixedUpdate()
    {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v);
     
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

    }
}
