using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public bool hasPeanut = false;
    public string currentPlayerPrefix = "Joy1";

    private int lifes = 3;
    public int Lifes { get { return lifes; } }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(currentPlayerPrefix + PC2D.Input.THROW) && hasPeanut)
        {
            Vector2 directionVector = (GetComponent<PlayerController2D>().Direction.Equals(Direction.left) ? Vector2.left : Vector2.right);
            directionVector.y = 1;
            GetComponent<PeanutSpawnScript>().throwPeanut(transform.position.x + directionVector.x * GetComponent<PeanutSpawnScript>().nutSpawnDistanceX, transform.position.y + GetComponent<PeanutSpawnScript>().nutSpawnDistanceY, directionVector * GetComponent<PeanutSpawnScript>().throwForce);
            //print(directionVector * throwForce);

            hasPeanut = false;

        }
    }

    public void reduceLife()
    {
        lifes = lifes - 1;
    }
}
