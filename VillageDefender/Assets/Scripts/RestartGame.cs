using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class RestartGame : MonoBehaviour {

	public GameObject displayGameOverDead;

	public void Restartgame() {
	//	SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
		Application.LoadLevel ("Dorf2");
		Time.timeScale = 1f;
		displayGameOverDead.SetActive (false);
	}

}