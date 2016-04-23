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
        if (collision.gameObject.tag == "Peanut" )
        {   
            if (!player.hasPeanut && !collision.gameObject.GetComponent<PeanutController>().wasThrown)
            {   
                player.hasPeanut = true;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.GetComponent<PeanutController>().wasThrown)
            {
                print("lost life");
                player.reduceLife();
                Destroy(collision.gameObject);
                //add random location
                GetComponent<PeanutSpawnScript>().spawnPeanutRandomLocation();
            }
            
        }
        
    }
}
