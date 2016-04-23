using UnityEngine;
using System.Collections;

public class PeanutSpawnScript : MonoBehaviour {

	public GameObject peanut;
	private PlayerController2D playerController; //movement and controls
    private PlayerController player;

    public float throwForce = 500;
    public float nutSpawnDistanceX = 1.01f;
    public float nutSpawnDistanceY = 0.2f;

    // Use this for initialization
    void Start () {
		playerController = transform.GetComponent<PlayerController2D> ();
        player = transform.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown(player.currentPlayerPrefix + PC2D.Input.THROW) && player.hasPeanut) 
		{
			Vector2 directionVector = (playerController.Direction.Equals (Direction.left) ? Vector2.left : Vector2.right);
            directionVector.y = 1;
            GameObject throwPeanut = spawnPeanut(transform.position.x + directionVector.x * nutSpawnDistanceX, transform.position.y + nutSpawnDistanceY);
            //print(directionVector * throwForce);
			throwPeanut.GetComponent<Rigidbody2D> ().AddForce(directionVector * throwForce);
            throwPeanut.GetComponent<PeanutController>().wasThrown = true;
            player.hasPeanut = false;

		}
	}


    private GameObject spawnPeanut(float x, float y)
    {
        return Instantiate(peanut, new Vector2(x,y), transform.rotation) as GameObject;
    }

    public void spawnPeanutRandomLocation()
    {
        //get random x, get random y
        spawnPeanut(1, 1);
    }
}
