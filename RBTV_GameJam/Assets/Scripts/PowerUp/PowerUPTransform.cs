using UnityEngine;
using System.Collections;

public class PowerUPTransform : MonoBehaviour
{

    public GameObject smokeEffect;
    private GameObject PowerChar;
    public GameObject ownBody;
    private GameObject temp;
    private float timer;
    private GameObject tempSmoke;
    private PlayerController controller;
    private bool rdyToShoot =true;
    public float attackForce;
    private GameObject AttackObject;
    public float attackSpawnDistance=1.1f;
    public AudioClip PowerSound;
    public AudioSource speaker;

    void Start()
    {
        controller = GetComponentInParent<PlayerController>();
        speaker = Camera.main.GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            Debug.Log("Instantiate");
            AttackObject = other.GetComponent<PowerUp>().GetAttack();
            tempSmoke = Instantiate(smokeEffect, transform.position, Quaternion.identity) as GameObject;
            this.PowerChar = other.GetComponent<PowerUp>().GetPowerChar();
            this.timer = other.GetComponent<PowerUp>().GetPowerTime();
            ChangeChild();
            if (PowerSound)
            {
                speaker.PlayOneShot(PowerSound);
            }
            Destroy(other.gameObject);
        }
    }

    void ChangeChild()
    {
        controller.hasPowerUp = true;
        ownBody.SetActive(false);
        temp = Instantiate(PowerChar, ownBody.transform.position, Quaternion.identity) as GameObject;
        temp.transform.parent = this.transform;
        StartCoroutine(ChangeBack(timer));
    }

    IEnumerator ChangeBack(float time)
    {
        yield return new WaitForSeconds(time);
        ownBody.SetActive(true);
        controller.hasPowerUp = false;
        Destroy(temp);
        Destroy(tempSmoke);
    }

    void ThrowLaser()
    {
        Vector2 directionVector = (GetComponent<PlayerController2D>().Direction.Equals(Direction.left) ? Vector2.left : Vector2.right);
        
        GetComponent<PeanutSpawnScript>().throwPeanut(transform.position.x + directionVector.x * GetComponent<PeanutSpawnScript>().nutSpawnDistanceX, transform.position.y + GetComponent<PeanutSpawnScript>().nutSpawnDistanceY, directionVector * GetComponent<PeanutSpawnScript>().throwForce, AttackObject);
    }

    void Update()
    {
        if (controller)
        {
            if (Input.GetButtonDown(controller.currentPlayerPrefix + PC2D.Input.THROW) && controller.hasPowerUp && rdyToShoot)
            {
                ThrowLaser();
                rdyToShoot = false;
                Invoke("resetShoot",0.2f);
            }
        }
        
    }

    void resetShoot()
    {
        rdyToShoot = true;
    }
}
