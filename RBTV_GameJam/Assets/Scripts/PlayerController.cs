using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject visual;

    public bool hasPeanut = false;
    public string currentPlayerPrefix = "Joy1";

    private bool immortalityGranted = false;
    public bool ImmortalityGranted { get { return immortalityGranted; } }

    public int lifes = 3;

    public float immortalityTime = 2f;

    public float throwAngle = 0.5f;
    public bool hasPowerUp = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(currentPlayerPrefix + PC2D.Input.THROW) && hasPeanut && !hasPowerUp )
        {
            Vector2 directionVector = (GetComponent<PlayerController2D>().Direction.Equals(Direction.left) ? Vector2.left : Vector2.right);
            directionVector.y = throwAngle;
            GetComponent<PeanutSpawnScript>().throwPeanut(transform.position.x + directionVector.x * GetComponent<PeanutSpawnScript>().nutSpawnDistanceX, transform.position.y + GetComponent<PeanutSpawnScript>().nutSpawnDistanceY, directionVector * GetComponent<PeanutSpawnScript>().throwForce, null);
            //print(directionVector * throwForce);

            hasPeanut = false;
        }
    }
    
    public void reduceLife()
    {
        lifes = lifes - 1;
        if (lifes == 0)
        {
            GameControl.instance.currentPlayers -= 1;
            if (GameControl.instance.currentPlayers == 1)
            {
                SceneManager.LoadScene(2);
            }
            Destroy(gameObject);  
        }
        StartCoroutine(LetPlayerBlink());
    }

    IEnumerator LetPlayerBlink()
    {
        if (!hasPowerUp)
        {
            for (float f = immortalityTime; f >= 0; f -= 0.1f)
            {
                immortalityGranted = true;
                visual.gameObject.SetActive(!visual.gameObject.activeSelf);
                yield return new WaitForSeconds(.1f);
            }
            immortalityGranted = false;
        }

    }
}
