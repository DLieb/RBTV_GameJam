using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AnyKey : MonoBehaviour {


	void Update () {

        if (Input.anyKey)
        {
            SceneManager.LoadScene(0);
        }
	}
}
