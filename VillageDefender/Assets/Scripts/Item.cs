using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Sprites;

public class Item : MonoBehaviour {

    public string itemName;
	public Sprite icon;

    public int count = 0;


    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        
    }

    public string getItemName()
    {
        return itemName;
    }

    public void addCount()
    {
       // count++;
    }

    public void subCount()
    {
        //count--;
    }

    public int getCount()
    {
        return count;
    }
}
