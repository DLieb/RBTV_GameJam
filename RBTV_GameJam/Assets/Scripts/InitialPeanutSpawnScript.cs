using UnityEngine;
using System.Collections;

public class InitialPeanutSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        PeanutSpawnScript temp = GetComponent<PeanutSpawnScript>();
        for (int i = 0; i < 4; i ++)
        {
            temp.spawnPeanutRandomLocation();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
