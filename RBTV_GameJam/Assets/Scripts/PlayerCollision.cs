using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = transform.GetComponent<PlayerController>();
    }
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Peanut" )
        {   
            if (!player.hasPeanut && !collision.gameObject.GetComponent<PeanutController>().wasThrown)
            {   
                player.hasPeanut = true;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.GetComponent<PeanutController>().wasThrown && !player.ImmortalityGranted)
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
