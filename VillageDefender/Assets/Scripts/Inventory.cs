using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public List<Item> items;

    public void showItem()
    {
       // Debug.Log(items[0].getCount());
    }

    public void addItem(Item item)
    {
        if (items.Contains(item))
        {
            item.addCount();
        }
        else
        {
            items.Add(item);
            item.addCount();
        }
    }

    public bool subItem(Item item)
    {
        if (items.Contains(item))
        {
            item.subCount();

            if(item.getCount() == 0)
            {
                items.Remove(item);
            }
            return true;
        }
        return false;
    }

    public List<Item> getItems()
    {
        return items;
    }
}
