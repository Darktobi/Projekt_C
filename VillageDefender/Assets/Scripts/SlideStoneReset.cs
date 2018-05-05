using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideStoneReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject[] slideStones = GameObject.FindGameObjectsWithTag("SlideStone");

            for (int i = 0; i < slideStones.Length; i++)
            {
                slideStones[i].GetComponent<SlidingStone>().reset();
            }
        }
    }
}
