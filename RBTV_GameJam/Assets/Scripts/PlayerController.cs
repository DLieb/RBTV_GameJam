using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool hasPeanut = false;
    public string currentPlayerPrefix = "Joy1";

    private int lifes = 3;
    public int Lifes { get { return lifes; } }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void reduceLife()
    {
        lifes = lifes - 1;
    }
}
