using UnityEngine;
using System.Collections;

public class PeanutThrowScript : MonoBehaviour {

	public GameObject peanut;
	private PlayerController2D playerController;

	public float throwForce = 15;

	// Use this for initialization
	void Start () {
		playerController = transform.GetComponent<PlayerController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//print(transform.position.x +" " + transform.position.y);
		//print(transform.forward.x +" " + transform.forward.y);

		if (Input.GetButtonDown(playerController.currentPlayerPrefix + PC2D.Input.THROW)) // currentPlayerPrefix + 
		{

			Vector2 directionVector = (playerController.Direction.Equals (Direction.left) ? Vector2.left : Vector2.right);

			GameObject throwPeanut = Instantiate (peanut, new Vector2(transform.position.x + directionVector.x * 2, transform.position.y), transform.rotation) as GameObject;
			throwPeanut.GetComponent<Rigidbody2D> ().AddForce(directionVector * throwForce);

		}
	}
}
