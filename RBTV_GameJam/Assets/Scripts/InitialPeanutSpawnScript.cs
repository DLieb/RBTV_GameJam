using UnityEngine;
using System.Collections;

public class InitialPeanutSpawnScript : MonoBehaviour {

    public int nrOfInitialSpawnedPeanuts = 4;

	// Use this for initialization
	void Start () {

        PeanutSpawnScript temp = GetComponent<PeanutSpawnScript>();
        for (int i = 0; i < nrOfInitialSpawnedPeanuts; i ++)
        {
            temp.spawnPeanutRandomLocation();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
