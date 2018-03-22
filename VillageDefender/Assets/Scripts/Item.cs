using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string itemName;

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
