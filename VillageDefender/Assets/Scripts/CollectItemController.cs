using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Item eingesammelt");
            Destroy(gameObject);
        }
    }

}
