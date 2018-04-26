using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
public class InventorySlot : MonoBehaviour {

	Item item;
	public Image icon;

	//public void AddItem (Item newItem)

	public void AddItem ()
	{
		//item = newItem;
		//icon.sprite = item.icon;
		icon.enabled = true;

	}
}
