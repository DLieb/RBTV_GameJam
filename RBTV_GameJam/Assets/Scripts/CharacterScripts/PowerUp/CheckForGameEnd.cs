using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckForGameEnd : MonoBehaviour {

	private bool gameEnd=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Debug.Log("current players: " + GameControl.instance.currentPlayers);
		if (GameControl.instance.currentPlayers == 1 && gameEnd == false)
        {
			gameEnd = true;
			StartCoroutine (EndGame());
        }

    }
	IEnumerator EndGame()
	{
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene(2);
	}
}
