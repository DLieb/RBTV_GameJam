using UnityEngine;
using System.Collections;

public class PeanutThrowScript : MonoBehaviour {

	public GameObject peanut;
	private PlayerController2D playerController;

	public float throwForce = 500;

	// Use this for initialization
	void Start () {
		playerController = transform.GetComponent<PlayerController2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown(playerController.currentPlayerPrefix + PC2D.Input.THROW)) 
		{
			Vector2 directionVector = (playerController.Direction.Equals (Direction.left) ? Vector2.left : Vector2.right);
            directionVector.y = 1;
			GameObject throwPeanut = Instantiate (peanut, 
                new Vector2(transform.position.x + (float) (directionVector.x * 1.4), transform.position.y), transform.rotation) as GameObject;
            print(directionVector * throwForce);
			throwPeanut.GetComponent<Rigidbody2D> ().AddForce(directionVector * throwForce);

		}
	}
}
