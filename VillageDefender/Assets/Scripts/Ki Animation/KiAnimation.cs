using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiAnimation : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rbody;
	GameObject target;
	public float speed = 1;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		target = GameObject.FindWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v2 = (target.transform.position - transform.position).normalized;
		GetComponent<Rigidbody2D>().velocity = v2 * speed;

		anim.SetFloat("input_x", v2.x);
		anim.SetFloat("input_y", v2.y);

	}
}
