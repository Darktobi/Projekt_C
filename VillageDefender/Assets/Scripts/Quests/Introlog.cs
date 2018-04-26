using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introlog : MonoBehaviour {

	public GameObject gameobj;
	private static bool angezeigt = false;

	public void ButtonClick(){
		

		gameobj.SetActive (false);
		angezeigt = true;

	}



	void Start()
	{
		if (angezeigt) {

			gameobj.SetActive (false);
		}

	}

}
