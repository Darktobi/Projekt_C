using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectable : MonoBehaviour {

    public GameObject item;
    public float interval = 2;

	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnItem", interval, interval);
	}
	

    void spawnItem()
    {
        System.Random rnd = new System.Random();
        int xValue = rnd.Next(-10, 11);
        int yValue = rnd.Next(-5, 6);
        GameObject g = (GameObject)Instantiate(item, new Vector3(xValue, yValue), Quaternion.identity);
    }
}
