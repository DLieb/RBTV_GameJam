﻿using UnityEngine;
using System.Collections;

public class PeanutSpawnScript : MonoBehaviour {

	public GameObject peanut;

    public float throwForce = 500;
    public float nutSpawnDistanceX = 1.01f;
    public float nutSpawnDistanceY = 0.2f;
    

    public void throwPeanut(float x, float y, Vector2 force)
    {
        GameObject throwPeanut = spawnPeanut(x, y);

        throwPeanut.GetComponent<Rigidbody2D>().AddForce(force);
        throwPeanut.GetComponent<PeanutController>().wasThrown = true;

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
