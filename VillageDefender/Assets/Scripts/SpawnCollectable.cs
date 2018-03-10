using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectable : MonoBehaviour {

    public GameObject spawnableItem;
    public float interval = 2;

    public int life = 3;
    public int maxNumberOfItems = 5;


    private void FixedUpdate()
    {
        if (life <= 0)
        {
            spawnItem();
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                life--;
            }
        }
    }

    void spawnItem()
    {
        
        System.Random rnd = new System.Random();
        int numberOfItems = rnd.Next(maxNumberOfItems + 1);
        int xPosition = (int)transform.position.x;
        int yPosition = (int)transform.position.y;

        for(int i = 0; i<=numberOfItems; i++)
        {
            int xValue = rnd.Next(xPosition -2, xPosition +2);
            int yValue = rnd.Next(yPosition -2, yPosition +2);
            GameObject g = (GameObject)Instantiate(spawnableItem, new Vector3(xValue, yValue), Quaternion.identity);
        }

    }
}
