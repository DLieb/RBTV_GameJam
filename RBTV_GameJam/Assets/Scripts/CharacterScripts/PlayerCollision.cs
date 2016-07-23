using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start ()
    {
        player = transform.GetComponent<PlayerController>();
    }
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Peanut" )
        {
            PeanutController pController = collision.gameObject.GetComponent<PeanutController>();
            if (!player.hasPeanut && !pController.wasThrown)
            {   
                player.hasPeanut = true;
                Destroy(collision.gameObject);
            }
            else if (pController.wasThrown && !player.ImmortalityGranted)
            {
                //print("lost life");
                if (player.reduceLife(pController.playerWhoHasThrown))
                {
                    Destroy(collision.gameObject);
                    //add random location
                    GetComponent<PeanutSpawnScript>().spawnPeanutRandomLocation();
                }
            }
        }
    }
}
