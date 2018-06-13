using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationWaypoint : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rbody;
	public GameObject waypoint_1;
	public GameObject waypoint_2;

	bool playerNotdetected = true;

	GameObject destination;
	GameObject player;
	public float speed = 1;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindWithTag("Player");
		destination = waypoint_1;
	}

	// Waypoint wechsel bei colision
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Waypoint") {

			if (destination == waypoint_1) {
				
				destination = waypoint_2;
			} else {
				destination = waypoint_1;
			}
		}
		//wenn spieler, dann halte an
		if (other.tag == "Player") {
			playerNotdetected = false;
			}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		playerNotdetected = true;
	}

	private void move()
	{
	Vector2 v2 = (destination.transform.position - transform.position).normalized;
	GetComponent<Rigidbody2D>().velocity = v2 * speed;

	//Befehle für den Animator 
	//Richtung
	anim.SetFloat("input_x", v2.x);
	anim.SetFloat("input_y", v2.y);

	//animator geht oder läuft
	if (v2 != Vector2.zero) {
		anim.SetBool ("is walking", true);
		} else {
		anim.SetBool ("is walking", false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (playerNotdetected) {
			//wenn Spieler, dann nicht bewegen
			move ();

		} else {
			//NPC steht
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			anim.SetBool ("is walking", false);
		
		}

	}

}
