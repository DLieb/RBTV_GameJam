using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CheckForGameEnd : MonoBehaviour {

	private bool gameEnd=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKey(KeyCode.Escape) && gameEnd == false)
        {
            gameEnd = true;
            GameControl.instance.SetPlayerList(new List<Player>());
            GameControl.instance.resetScoreBoard();
            GameControl.instance.resetPlayersLeftInGame();
            GameControl.instance.currentPlayers = 0;
            SceneManager.LoadScene(0);
        }
        //Debug.Log("current players: " + GameControl.instance.currentPlayers);
        if (GameControl.instance.currentPlayers == 1 && gameEnd == false)
        {
			gameEnd = true;
            GameControl.instance.setPlayerWon();
            StartCoroutine (EndGame());
        }

    }
	IEnumerator EndGame()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene(2);
	}
}
