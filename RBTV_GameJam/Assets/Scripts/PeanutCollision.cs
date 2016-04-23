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
        if (collision == null)
        {
            print("go");
        }
        if (collision.gameObject.tag == "Peanut")
        {
            if (!player.hasPeanut && !collision.gameObject.GetComponent<PeanutController>().wasThrown)
            {
                Debug.Log("collision wih peanut");
                
                player.hasPeanut = true;
            }
            else if (collision.gameObject.GetComponent<PeanutController>().wasThrown)
            {
                print("lost life");
                player.reduceLife();
                //add random location
                GetComponent<PeanutSpawnScript>().spawnPeanutRandomLocation();
            }
            Destroy(collision.gameObject);
        }
        
    }
}
