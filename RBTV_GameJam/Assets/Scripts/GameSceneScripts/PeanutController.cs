using UnityEngine;
using System.Collections;

public class PeanutController : MonoBehaviour {

    public bool wasThrown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Peanut")
        {
            wasThrown = false;
        }
    }
}
