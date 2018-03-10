using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int collectedWood = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addWood()
    {
        collectedWood++;
       
    }

    public int getCollectedWood()
    {
        return collectedWood;
    }
}
