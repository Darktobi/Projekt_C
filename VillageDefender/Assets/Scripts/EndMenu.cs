using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndMenu : MonoBehaviour {

    public void StartGame()
    {
        GameObject.Find("Player").GetComponent<Player>().Reset();
        GameObject.Find("Player").GetComponent<PlayerMovementController>().startPoint = "";
        GameObject.Find("Bruecke").SetActive(false);
        DialogueManager.questprogress = 0;
        SceneManager.LoadScene("Dorf2");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
