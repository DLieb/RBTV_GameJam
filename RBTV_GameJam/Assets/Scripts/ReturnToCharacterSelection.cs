using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ReturnToCharacterSelection : MonoBehaviour {


	void Update () {

        if (Input.anyKey)
        {
            GameControl.instance.SetPlayerList(new List<Player>());
            GameControl.instance.currentPlayers = 0;
            SceneManager.LoadScene(0);
        }
	}
}
