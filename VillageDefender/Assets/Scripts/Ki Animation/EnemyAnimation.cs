using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void animate(Vector2 dir, bool isWalking)
    {
        anim.SetFloat("input_x", dir.x);
        anim.SetFloat("input_y", dir.y);

        if (isWalking)
        {
            anim.SetBool("is walking", true);
        }
        else
        {
            anim.SetBool("is walking", false);
        }
    }
}
