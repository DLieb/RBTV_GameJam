using UnityEngine;
using System.Collections;

public class PeanutCollision : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = transform.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("coll handler");
        if (collision.gameObject.tag == "Peanut" && !player.hasPeanut)
        {
            Debug.Log("collision wih peanut");
            Destroy(collision.gameObject);
            player.hasPeanut = true;
        }
    }
}
