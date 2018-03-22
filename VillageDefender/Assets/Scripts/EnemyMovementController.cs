using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public float speed = 1;

    GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 v2 = (target.transform.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = v2 * speed;
	}
}
