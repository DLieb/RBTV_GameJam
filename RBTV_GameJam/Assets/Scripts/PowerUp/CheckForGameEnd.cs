using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CheckForGameEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("current players: " + GameControl.instance.currentPlayers);
        if (GameControl.instance.currentPlayers == 1)
        {
            SceneManager.LoadScene(2);
        }

    }
}
