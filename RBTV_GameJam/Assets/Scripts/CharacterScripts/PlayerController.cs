using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject visual;
	public GameObject deathEffect;
    public GameObject nussAnzeige;
    public string playerName ="";


    public bool hasPeanut = false;
    public string currentPlayerPrefix = "Joy1";

    private bool immortalityGranted = false;
    public bool ImmortalityGranted
    {
        get { return immortalityGranted; }
        set { immortalityGranted = value; }
    }
    private AudioSource speaker;
    public AudioClip[] hitSounds;
	public AudioClip deathSound;
   

    public int lifes = 3;

    public float immortalityTime = 2f;

    public float throwAngle = 0.5f;
    public bool hasPowerUp = false;

    // Use this for initialization
    void Start ()
    {
        speaker = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(currentPlayerPrefix + PC2D.Input.THROW) && hasPeanut && !hasPowerUp )
        {
            Vector2 directionVector = (GetComponent<PlayerController2D>().Direction.Equals(Direction.left) ? Vector2.left : Vector2.right);
            directionVector.y = throwAngle;
            GetComponent<PeanutSpawnScript>().throwPeanut(transform.position.x + directionVector.x * GetComponent<PeanutSpawnScript>().nutSpawnDistanceX, transform.position.y + GetComponent<PeanutSpawnScript>().nutSpawnDistanceY, directionVector * GetComponent<PeanutSpawnScript>().throwForce, null,playerName);
            //print(directionVector * throwForce);

            hasPeanut = false;
        }
	    if (this.transform.position.y > 13 || this.transform.position.y < -20 || this.transform.position.x < -20 ||
	        this.transform.position.x > 20)
	    {
	        transform.position = new Vector2(0, 0);
	    }
	    if (hasPeanut && !nussAnzeige.activeSelf && !hasPowerUp)
	    {
	        nussAnzeige.SetActive(true);
	       // Debug.Log("Nuss On");
	    }
	    else if(!hasPeanut && nussAnzeige.activeSelf || hasPowerUp)
	    {
            nussAnzeige.SetActive(false);
            //Debug.Log("Nuss Off");
        }
    }
    
    public bool reduceLife( string playerThatThrow)
    {
        if (playerThatThrow != playerName)
        {
            lifes = lifes - 1;
            if (hitSounds.Length > 0 && !speaker.isPlaying)
            {
                speaker.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
            }
            GameControl.instance.addScore(playerThatThrow, ScoreEnum.hits);
            if (lifes == 0)
            {
                GameControl.instance.reducePlayerCount();
                if (deathSound)
                {
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(deathSound);
                }
                if (deathEffect)
                {
                    Instantiate(deathEffect, transform.position, Quaternion.identity);
                }
                GameControl.instance.reducePlayersLeftInGame(playerName);
                GameControl.instance.addScore(playerThatThrow, ScoreEnum.kills);
                Destroy(gameObject);
            }
            StartCoroutine(LetPlayerBlink());
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator LetPlayerBlink()
    {
        if (!hasPowerUp)
        {
            for (float f = immortalityTime; f >= 0; f -= 0.1f)
            {
				if (hasPowerUp) 
				{
					visual.gameObject.SetActive (false);
					break;
				}
                immortalityGranted = true;
                visual.gameObject.SetActive(!visual.gameObject.activeSelf);
                yield return new WaitForSeconds(.1f);
            }
			if (!hasPowerUp) 
			{
				immortalityGranted = false;
			}
        }

    }
}
