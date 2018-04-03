using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventaropen : MonoBehaviour {

	public Animator animator;


	public void OpenCloseInventory ()
	{
		if (animator.GetBool ("isOpen")) {
			animator.SetBool ("isOpen", false);
		} 
		else 
		{
			animator.SetBool ("isOpen", true);
		}
	}


}
