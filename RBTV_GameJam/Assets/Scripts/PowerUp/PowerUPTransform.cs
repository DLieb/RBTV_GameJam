﻿using UnityEngine;
using System.Collections;

public class PowerUPTransform : MonoBehaviour
{

    public GameObject smokeEffect;
    private GameObject PowerChar;
    public GameObject ownBody;
    private GameObject tempBody;
    private float timer;
    private GameObject tempSmoke;
    private PlayerController controller;
    private bool rdyToShoot =true;
    public float attackForce;
    private GameObject AttackObject;
    public float attackSpawnDistance=1.1f;
    public AudioClip PowerSound;
    public AudioSource speaker;
    private GameObject swordAttack;
    private Vector2 SwordLeft;
    private Vector2 SwordRight;
    private Vector2 tempDirection;
    public bool hasPowerUp=false;

    void Start()
    {
        controller = GetComponentInParent<PlayerController>();
        speaker = Camera.main.GetComponent<AudioSource>();
    }


    public void transformPower(GameObject Attack,GameObject Char, float timer)
    {
        if (!hasPowerUp)
        {
            AttackObject = Attack;
            this.PowerChar = Char;
            this.timer = timer;
            controller.ImmortalityGranted = true;
            tempSmoke = Instantiate(smokeEffect, transform.position, Quaternion.identity) as GameObject;
            StartCoroutine(DestroyObject(tempSmoke, 1.5f));
            ChangeChild();
            if (PowerSound)
            {
                speaker.PlayOneShot(PowerSound);
            }
            hasPowerUp = true;
        }
      
    }
    void ChangeChild()
    {
        controller.hasPowerUp = true;
        ownBody.SetActive(false);
        tempBody = Instantiate(PowerChar, ownBody.transform.position, Quaternion.identity) as GameObject;
        tempBody.transform.parent = this.transform;
        if (AttackObject.name == "Cut_D")
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            Vector2 spawnPosition = new Vector2(transform.position.x + 1.25f, transform.position.y);
            Quaternion spawnRotation = Quaternion.Euler(0,180,0);
            swordAttack = Instantiate(AttackObject, spawnPosition, spawnRotation) as GameObject;
            swordAttack.transform.parent = tempBody.transform;
        }
        StartCoroutine(ChangeBack(timer, tempBody));
    }

    IEnumerator DestroyObject(GameObject toDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(toDestroy);
    }

    IEnumerator ChangeBack(float time, GameObject powerBody)
    {
        yield return new WaitForSeconds(time);
        Destroy(powerBody);
        ownBody.SetActive(true);
        controller.hasPowerUp = false;
        controller.ImmortalityGranted = false;
        if (swordAttack)
        {
            Destroy(swordAttack);
        }
        gameObject.layer = LayerMask.NameToLayer("Default");
        hasPowerUp = false;
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
                if (AttackObject.name == "Cut_D")
                {
                    MeleeAttack();
                }
                else
                {
                    ThrowLaser();
                }
                rdyToShoot = false;
                Invoke("resetShoot",0.2f);
            }
        }
        
    }

    void resetShoot()
    {
        rdyToShoot = true;
    }

    void MeleeAttack()
    {
        Vector2 directionVector = (GetComponent<PlayerController2D>().Direction.Equals(Direction.left) ? Vector2.left : Vector2.right);
        Vector2 temp = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(temp, directionVector);
        if (Vector2.Distance(transform.position, hit.transform.position) <= 3.5 && hit.transform.tag=="Player" && !hit.transform.GetComponent<PlayerController>().ImmortalityGranted)
        {
            Debug.Log(hit.rigidbody.gameObject.name);
            hit.transform.GetComponent<PlayerController>().reduceLife();
        }
       /* if (tempDirection != directionVector)
        {
            Vector2 tempPos = swordAttack.transform.localPosition;
            tempPos.x = tempPos.x*-1;
            tempDirection = directionVector;
            swordAttack.transform.localPosition = tempPos;
            Vector3 tempRot = swordAttack.transform.localEulerAngles;
            tempRot.y += 180;
            if (tempRot.y == 360)
            {
                tempRot.y = 0;
            }
            swordAttack.transform.localEulerAngles = tempRot;
        }*/
        swordAttack.SetActive(true);
    }
}
