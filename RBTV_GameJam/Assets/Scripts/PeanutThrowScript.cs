using UnityEngine;
using System.Collections;

public class PeanutThrowScript : MonoBehaviour {

	public GameObject peanut;
	private PlayerController2D playerController; //movement and controls
    private PlayerController player;

    public float throwForce = 500;

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
			GameObject throwPeanut = Instantiate (peanut, 
                new Vector2(transform.position.x + directionVector.x * 1.01f, transform.position.y + 0.2f), transform.rotation) as GameObject;
            //print(directionVector * throwForce);
			throwPeanut.GetComponent<Rigidbody2D> ().AddForce(directionVector * throwForce);
            player.hasPeanut = false;

		}
	}
}
