using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

	public Image healthstatus;
	public GameObject healthbar;
	private int maxlife;

	// Use this for initialization
	void Start () {

		maxlife = GetComponent<Enemy> ().health;

	}

	// Update is called once per frame
	void Update () {
		//Lebens Balken nur bei Schaden anzeigen
		if (maxlife != GetComponent<Enemy> ().health) {
			healthbar.SetActive (true);
		}

		healthstatus.fillAmount = (float)GetComponent<Enemy> ().health / (float)maxlife;
	}
}
